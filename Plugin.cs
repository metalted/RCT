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
        public const string pluginVersion = "1.4";
        public LEV_LevelEditorCentral central;

        public static Plugin Instance;

        //RCT
        public Material rctMaterial;
        public bool rctMode = false;
        public Vector3 startingPosition = Vector3.zero;
        public Quaternion startingRotation = Quaternion.identity;
        public List<RCTBlock> blockChain = new List<RCTBlock>();

        //UI
        private Rect windowRect = new Rect(20, 20, 250, 300);

        //Settings
        public ConfigEntry<KeyCode> rctButton;
        public ConfigEntry<KeyCode> deleteChainButton;
        public ConfigEntry<KeyCode> solidifyChainButton;
        public ConfigEntry<KeyCode> undoButton;
        public ConfigEntry<KeyCode> flipButton;
        public ConfigEntry<KeyCode> reverseButton;
        public ConfigEntry<KeyCode> resetRotationButton;

        public ConfigEntry<int> rctBlockID;
        public ConfigEntry<bool> visualizeConnectPoints;
        public ConfigEntry<bool> deleteOnSolidify;

        public void Awake()
        {
            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();

            Instance = this;

            //Controls
            rctButton = Config.Bind("Controls", "Toggle RCT Mode", KeyCode.Keypad0, "Toggle RCT Mode, select a single block with the configured ID first.");
            deleteChainButton = Config.Bind("Controls", "Delete Chain", KeyCode.None, "Delete all the RCT blocks in the chain, clearing the design. Deleting is final.");
            solidifyChainButton = Config.Bind("Controls", "Solidify Chain", KeyCode.None, "Turns the design into actual blocks.");
            undoButton = Config.Bind("Controls", "Undo", KeyCode.None, "Remove the last placed rct block from the design.");
            flipButton = Config.Bind("Controls", "Flip", KeyCode.None, "Flip the last rct block connected.");
            reverseButton = Config.Bind("Controls", "Reverse", KeyCode.None, "Reverse the last rct block connected.");
            resetRotationButton = Config.Bind("Controls", "Reset Rotation", KeyCode.None, "Reset the rotation of the last rct block connected.");

            //Preferences
            rctBlockID = Config.Bind("Preferences", "RCT Block ID", 69, "The block that will be used to configure the start position and rotation of the chain.");
            visualizeConnectPoints = Config.Bind("Preferences", "Show connection points", false, "Visualizes the connection points configured in the plugin. Mostly used for debugging purposes.");
            deleteOnSolidify = Config.Bind("Preferences", "Delete on Solidify", false, "When solidifying a chain, also clear the design");
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

                if(Input.GetKeyDown(deleteChainButton.Value))
                {
                    DeleteChain();
                }

                if(Input.GetKeyDown(solidifyChainButton.Value))
                {
                    SolidifyChain();
                }

                if(Input.GetKeyDown(undoButton.Value))
                {
                    Undo();
                }

                if (Input.GetKeyDown(flipButton.Value))
                {
                    FlipLastBlock();
                }

                if(Input.GetKeyDown(reverseButton.Value))
                {
                    ReverseLastBlock();
                }

                if(Input.GetKeyDown(resetRotationButton.Value))
                {
                    ResetRotationLastBlock();
                }
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

            if (GUILayout.Button("Delete Chain" + ( deleteChainButton.Value != KeyCode.None ? (" (" + deleteChainButton.Value.ToString() + ")") : "")))
            {
                DeleteChain();
            }

            if (GUILayout.Button("Solidify Chain" + (solidifyChainButton.Value != KeyCode.None ? (" (" + solidifyChainButton.Value.ToString() + ")") : "")))
            {
                SolidifyChain();
            }

            if (GUILayout.Button("Undo" + (undoButton.Value != KeyCode.None ? (" (" + undoButton.Value.ToString() + ")") : "")))
            {
                Undo();
            }

            if (GUILayout.Button("Flip" + (flipButton.Value != KeyCode.None ? (" (" + flipButton.Value.ToString() + ")") : "")))
            {
                FlipLastBlock();
            }

            if (GUILayout.Button("Reverse" + (reverseButton.Value != KeyCode.None ? (" (" + reverseButton.Value.ToString() + ")") : "")))
            {
                ReverseLastBlock();
            }

            if (GUILayout.Button("Reset Rotation" + (resetRotationButton.Value != KeyCode.None ? (" (" + resetRotationButton.Value.ToString() + ")") : "")))
            {
                ResetRotationLastBlock();
            }

            if (blockChain.Count > 1)
            {
                RCTBlock last = GetLastBlock();
                float normalizedRotation = (last.rotation % 360 + 360) % 360;
                GUILayout.Label("Rotation: " + normalizedRotation.ToString("F3"));
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

                if(blockChain.Count > 0)
                {
                    foreach(RCTBlock b in blockChain)
                    {
                        b.gameObject.SetActive(false);
                    }
                }

                PlayerManager.Instance.messenger.Log("RCT: Off", 1f);
                return;
            }

            if(blockChain.Count > 0)
            {
                rctMode = true;

                foreach (RCTBlock b in blockChain)
                {
                    b.gameObject.SetActive(true);
                }

                PlayerManager.Instance.messenger.Log("RCT: On", 1f);
                central.selection.DeselectAllBlocks(false, "");
                return;
            }

            if (central.selection.list.Count == 1)
            {
                if (central.selection.list[0].blockID == rctBlockID.Value)
                {
                    rctMode = true;
                    startingPosition = central.selection.list[0].transform.position;
                    startingRotation = central.selection.list[0].transform.rotation;

                    PlayerManager.Instance.messenger.Log("RCT: On", 1f);
                    central.selection.DeselectAllBlocks(false, "");                                
                }
                else
                {
                    string blockName = "Error";
                    try
                    {
                        blockName = PlayerManager.Instance.loader.globalBlockList.blocks[rctBlockID.Value].name;
                    }
                    catch { }

                    PlayerManager.Instance.messenger.Log("To enable RCT Mode: \n(1) Deselect all. \n(2) Select block [ID: " + rctBlockID.Value + " | Name: " + blockName + "]. \n(3) Press [" + ((KeyCode)rctButton.Value).ToString() + "]", 8f);
                }
            }
            else
            {
                string blockName = "Error";
                try
                {
                    blockName = PlayerManager.Instance.loader.globalBlockList.blocks[rctBlockID.Value].name;
                }
                catch { }

                PlayerManager.Instance.messenger.Log("To enable RCT Mode: \n(1) Deselect all. \n(2) Select block [ID: " + rctBlockID.Value + " | Name: " + blockName + "]. \n(3) Press [" + ((KeyCode)rctButton.Value).ToString() + "]", 8f);
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
                PlayerManager.Instance.messenger.Log("Block not supported by RCT.", 1f);
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
                GetLastBlock().transform.rotation = startingRotation;
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

            GameObject start = visualizeConnectPoints.Value ? GameObject.CreatePrimitive(PrimitiveType.Cube) : new GameObject("Start");
            Collider startCollider = start.GetComponent<Collider>();
            if(startCollider != null)
            {
                GameObject.Destroy(startCollider);
            }            
            start.transform.parent = block.transform;
            start.transform.localPosition = connections.localStartPosition;
            start.transform.localEulerAngles = connections.localStartEuler;
            start.gameObject.name = "Start";
            rct.start = start.transform;

            GameObject end = visualizeConnectPoints.Value ? GameObject.CreatePrimitive(PrimitiveType.Cube) : new GameObject("End");
            Collider endCollider = end.GetComponent<Collider>();
            if (endCollider != null)
            {
                GameObject.Destroy(endCollider);
            }
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

            if (last.isFlipped && last.isReversed && last.connectionPoints.connectionType == ConnectionData.ConnectionType.Curve)
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
            else if(last.isFlipped && last.isReversed && last.connectionPoints.connectionType == ConnectionData.ConnectionType.Shift)
            {
                // Use last.end's local rotation and position
                Quaternion adjustedLocalRotation = last.start.localRotation;
                Vector3 adjustedLocalPosition = last.start.localPosition;

                // Adjust for reversing first (rotate 180 degrees around Y-axis)
                //adjustedLocalRotation *= Quaternion.Euler(0, 180f, 0);

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

            last.rotation = 0f;
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
            last.rotation += angle;
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

        public void ResetRotationLastBlock()
        {
            if (blockChain.Count == 1)
            {
                PlayerManager.Instance.messenger.Log("Can't reset rotation of first object in chain.", 2f);
                return;
            }

            RCTBlock last = GetLastBlock();
            RCTBlock penultimate = GetPenultimateBlock();

            if (last == null || penultimate == null)
            {
                Debug.LogError("Trying to reset rotation of last block but last or penultimate is null!");
                return;
            }

            float currentRotation = last.rotation;
            RotateLastBlock(-currentRotation);
            last.rotation = 0;
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

            if (deleteOnSolidify.Value)
            {
                DeleteChain();
            }
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