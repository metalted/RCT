using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BepInEx.Configuration;

namespace RCT
{      
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.rct";
        public const string pluginName = "RCT";
        public const string pluginVersion = "1.1";
        public LEV_LevelEditorCentral central;

        public static Plugin Instance;
        public Material rctMaterial;
        public bool rctMode = false;
        public Vector3 startingPosition = Vector3.zero;
        private Rect windowRect = new Rect(20, 20, 250, 300);
        public ConfigEntry<KeyCode> rctButton;
        public List<RCTBlock> blockChain = new List<RCTBlock>();
        public bool visualizeConnectionPoints = true;

        public void Awake()
        {
            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();

            Instance = this;
            rctButton = Config.Bind("Controls", "Toggle RCT Mode", KeyCode.Keypad0, "Toggle RCT Mode");
        }

        public void Update()
        {
            if (central == null)
            {
                return;
            }

            if (Input.GetKeyDown(rctButton.Value))
            {
                ToggleRCTMode();
            }

            if (rctMode)
            {
                RotateLastBlockWithScroll();
            }
        }

        private void OnGUI()
        {
            if (rctMode)
            {
                // Make the window draggable and define its contents
                windowRect = GUI.Window(0, windowRect, DrawRCTWindow, "RCT Controls");
            }
        }

        // Define the contents of the GUI window
        private void DrawRCTWindow(int windowID)
        {
            GUILayout.BeginVertical();

            if (GUILayout.Button("Delete Chain"))
            {
                DeleteChain();
            }

            if (GUILayout.Button("Solidify Chain"))
            {
                SolidifyChain();
            }

            if (GUILayout.Button("Undo"))
            {
                Undo();
            }

            if (GUILayout.Button("Flip"))
            {
                FlipLastBlock();
            }

            if (GUILayout.Button("Reverse"))
            {
                ReverseLastBlock();
            }

            GUILayout.EndVertical();

            // Make the window draggable
            GUI.DragWindow();
        }

        public void ToggleRCTMode()
        {
            if (rctMode)
            {
                rctMode = false;
                PlayerManager.Instance.messenger.Log("RCT: Off", 1f);
                return;
            }

            if(blockChain.Count > 0)
            {
                rctMode = true;
                PlayerManager.Instance.messenger.Log("RCT: On", 1f);
                central.selection.DeselectAllBlocks(false, "");
                return;
            }

            if (central.selection.list.Count == 1)
            {
                if (central.selection.list[0].blockID == 1329)
                {
                    rctMode = true;
                    startingPosition = central.selection.list[0].transform.position;
                    PlayerManager.Instance.messenger.Log("RCT: On", 1f);
                    central.selection.DeselectAllBlocks(false, "");                                
                }
                else
                {
                    PlayerManager.Instance.messenger.Log("Select a single pivot as start position and press [" + ((KeyCode)rctButton.Value).ToString() + "] to enable RCT mode!", 3f);
                }
            }
            else
            {
                PlayerManager.Instance.messenger.Log("Select a single pivot as start position and press [" + ((KeyCode)rctButton.Value).ToString() + "] to enable RCT mode!", 3f);
            }
        }

        public void OnLevelEditor(LEV_LevelEditorCentral levCentral)
        {
            central = levCentral;
            rctMaterial = MaterialManager.AllMaterials[100].material;
            rctMode = false;
            blockChain.Clear();
        }

        public void OnNotLevelEditor()
        {
            central = null;
            rctMode = false;
            blockChain.Clear();
        }

        public void BlockSelectedInBlockGUI(int blockID)
        {
            //Check if block is supported.
            if (!ConnectionData.Supports(blockID))
            {
                PlayerManager.Instance.messenger.Log("Unsupported :(", 1f);
                return;
            }

            RCTBlock block = CreateRCTBlock(blockID);
            if(block == null)
            {
                return;
            }

            blockChain.Add(block);

            if(blockChain.Count == 1)
            {
                GetLastBlock().transform.position = startingPosition;
            }

            if (blockChain.Count > 1)
            {
                //AlignTube(blockChain[blockChain.Count - 2].end, blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 1].start);
                AlignLastBlock();
            }
        }

        public RCTBlock CreateRCTBlock(int id)
        {
            BlockConnectionPoints connections = ConnectionData.GetBlockConnectionPoints(id);
            if (!connections.valid)
            {
                Debug.LogError("GetBlockConnectionPoints(" + id + ") is invalid. Use ConnectionData.Supports(id) first!");
                return null;
            }

            //Create the block.
            BlockProperties blockProperties = Object.Instantiate<BlockProperties>(PlayerManager.Instance.loader.globalBlockList.blocks[id]);
            blockProperties.CreateBlock();
            for (int index = 0; index < blockProperties.propertyScripts.Count; ++index)
            {
                blockProperties.propertyScripts[index].CreateBlock(blockProperties);
            }

            //Set all objects to the rct material
            Properties_RoadPainter component = blockProperties.gameObject.GetComponent<Properties_RoadPainter>();
            foreach (MeshRenderer ren in component.renderers)
            {
                Material[] sharedMaterials = ren.sharedMaterials;
                for (int i = 0; i < sharedMaterials.Length; ++i)
                {
                    sharedMaterials[i] = rctMaterial;
                }
                ren.sharedMaterials = sharedMaterials;
            }

            GameObject block = blockProperties.gameObject;
            
            Utils.RemoveUnwantedComponents(block);
            RCTBlock rct = block.AddComponent<RCTBlock>();
            rct.blockID = id;
            rct.connectionPoints = connections;

            GameObject start = visualizeConnectionPoints ? GameObject.CreatePrimitive(PrimitiveType.Cube) : new GameObject("Start");
            start.transform.parent = block.transform;
            start.transform.localPosition = connections.localStartPosition;
            start.transform.localEulerAngles = connections.localStartEuler;
            start.gameObject.name = "Start";
            rct.start = start.transform;

            GameObject end = visualizeConnectionPoints ? GameObject.CreatePrimitive(PrimitiveType.Cube) : new GameObject("End");
            end.transform.parent = block.transform;
            end.transform.localPosition = connections.localEndPosition;
            end.transform.localEulerAngles = connections.localEndEuler;
            end.gameObject.name = "End";
            rct.end = end.transform;

            return rct;
        }

        public void AlignLastBlock()
        {
            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to align blocks but last or penultimate is null!");
                return;
            }

            if (last.isFlipped && last.isReversed && last.connectionPoints.isBend)
            {
                // Use last.end's local rotation and position
                Quaternion adjustedLocalRotation = last.start.localRotation;
                Vector3 adjustedLocalPosition = last.start.localPosition;

                // Adjust for reversing first (rotate 180 degrees around Y-axis)
                adjustedLocalRotation *= Quaternion.Euler(0, 180f, 0);

                // Adjust for flipping after reversing (negative scale on X-axis)
                adjustedLocalRotation = new Quaternion(
                    -adjustedLocalRotation.x,
                    adjustedLocalRotation.y,
                    -adjustedLocalRotation.z,
                    adjustedLocalRotation.w
                );
                adjustedLocalPosition.x = -adjustedLocalPosition.x;

                // Calculate the new rotation
                last.transform.rotation = penultimate.end.rotation * Quaternion.Inverse(adjustedLocalRotation);

                // Calculate the new position
                Vector3 offset = last.transform.rotation * adjustedLocalPosition;
                last.transform.position = penultimate.end.position - offset;
            }
            else
            {
                //Adjust rotation
                last.transform.rotation = penultimate.end.rotation * Quaternion.Inverse(last.start.localRotation);
                //Adjust position
                Vector3 offset = last.transform.rotation * last.start.localPosition;
                last.transform.localPosition = penultimate.end.position - offset;
            }            
        }

        public RCTBlock GetLastBlock()
        {
            if(blockChain.Count > 0)
            {
                return blockChain[blockChain.Count - 1];
            }

            return null;
        }

        public RCTBlock GetPenultimateBlock()
        {
            if(blockChain.Count > 1)
            {
                return blockChain[blockChain.Count - 2];
            }

            return null;
        }

        public void RotateLastBlockWithScroll()
        {
            float scrollValue = Input.mouseScrollDelta.y;
            if(scrollValue == 0)
            {
                return;
            }

            if (!central.cam.IsCursorInGameView())
            {
                return;
            }

            RCTBlock last = GetLastBlock();

            if (last == null)
            {
                return;
            }

            float rotationValue = central.gizmos.list_gridR[central.gizmos.index_gridR] * Mathf.Sign(scrollValue);
            RotateLastBlock(rotationValue);
        }

        public void RotateLastBlock(float angle)
        {
            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to rotate last block but last or penultimate is null!");
                return;
            }

            last.transform.RotateAround(penultimate.end.position, penultimate.end.forward, angle);
        }

        public void FlipLastBlock()
        {
            if(blockChain.Count == 1)
            {
                PlayerManager.Instance.messenger.Log("Can't flip first object in chain.", 2f);
                return;
            }

            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to flip last block but last or penultimate is null!");
                return;
            }

            Vector3 flipped = last.transform.localScale;
            flipped.x *= -1;
            last.transform.localScale = flipped;

            last.isFlipped = !last.isFlipped;

            AlignLastBlock();
        }

        public void ReverseLastBlock()
        {
            if (blockChain.Count == 1)
            {
                PlayerManager.Instance.messenger.Log("Can't reverse first object in chain.", 2f);
                return;
            }

            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to reverse last block but last or penultimate is null!");
                return;
            }

            //Switch the connection points
            Transform temp = last.start;
            last.start = last.end;
            last.end = temp;

            //Rotate the endpoints so the look the other way
            last.start.Rotate(0, 180, 0);
            last.end.Rotate(0, 180, 0);

            last.isReversed = !last.isReversed;

            AlignLastBlock();
        }

        public void Undo()
        {
            RCTBlock last = GetLastBlock();

            if(last == null)
            {
                Debug.LogError("Can't undo without blocks!");
                return;
            }

            //Destroy and remove
            GameObject.Destroy(blockChain[blockChain.Count - 1].gameObject);
            blockChain.RemoveAt(blockChain.Count - 1);
        }

        public void DeleteChain()
        {
            foreach (RCTBlock b in blockChain)
            {
                if(b.gameObject != null)
                {
                    GameObject.Destroy(b.gameObject);
                }               
            }

            blockChain.Clear();
        }

        public void SolidifyChain()
        {
            central.selection.DeselectAllBlocks(true, "");

            if(blockChain.Count == 0)
            {
                return;
            }

            List<string> before = Enumerable.Repeat((string)null, blockChain.Count).ToList();

            //Create a list of selections before the creation, which is empty.
            List<string> beforeSelection = new List<string>();

            //Stores the JSON strings of the blocks after creation.
            List<string> after = new List<string>();
            //Stores the selection after creation.
            List<string> afterSelection = new List<string>();

            //Stores the BlockProperties objects of the created blocks.
            List<BlockProperties> blockList = new List<BlockProperties>();

            foreach (RCTBlock block in blockChain)
            {
                //Create the actual block at this position and rotation
                BlockProperties blockProperties = Object.Instantiate<BlockProperties>(PlayerManager.Instance.loader.globalBlockList.blocks[block.blockID]);
                blockProperties.isBeingCreated = true;
                blockProperties.gameObject.name = PlayerManager.Instance.loader.globalBlockList.blocks[block.blockID].name;
                blockProperties.UID = central.manager.GenerateUniqueIDforBlocks(block.blockID.ToString());
                blockProperties.isEditor = true;
                blockProperties.CreateBlock();
                for (int index = 0; index < blockProperties.propertyScripts.Count; ++index)
                {
                    blockProperties.propertyScripts[index].CreateBlock(blockProperties);
                }

                blockProperties.transform.position = block.transform.position;
                blockProperties.transform.rotation = block.transform.rotation;
                blockProperties.transform.localScale = block.transform.localScale;

                after.Add(blockProperties.ConvertBlockToJSON_v15_string());
                blockList.Add(blockProperties);
            }

            afterSelection = central.undoRedo.ConvertSelectionToStringList(blockList);

            //Convert all the before and after data into a Change_Collection.
            Change_Collection collection = central.undoRedo.ConvertBeforeAndAfterListToCollection(
                before, after,
                blockList,
                beforeSelection, afterSelection);

            //Register the creation
            central.validation.BreakLock(collection, "Gizmo6");

            //Select all the created objects.
            central.selection.UndoRedoReselection(blockList);

            DeleteChain();
        }        
    }

    [HarmonyPatch(typeof(LEV_LevelEditorCentral), "Awake")]
    public class LEVLevelEditorCentralAwakePatch
    {
        public static void Postfix(LEV_LevelEditorCentral __instance)
        {
            Plugin.Instance.OnLevelEditor(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_GizmoHandler), "CreateNewBlock")]
    public class LEVGizmoHandlerCreateNewBlockPatch
    {
        public static bool Prefix(ref int blockID)
        {
            if (Plugin.Instance.rctMode)
            {
                Plugin.Instance.BlockSelectedInBlockGUI(blockID);
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    [HarmonyPatch(typeof(MainMenuUI), "Awake")]
    public class MainMenuUIAwakePatch
    {
        public static void Postfix()
        {
            Plugin.Instance.OnNotLevelEditor();
        }
    }

    [HarmonyPatch(typeof(SetupGame), "Awake")]
    public class SetupGameAwakePatch
    {
        public static void Postfix()
        {
            Plugin.Instance.OnNotLevelEditor();
        }
    }
}