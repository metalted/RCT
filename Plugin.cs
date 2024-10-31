using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BepInEx.Configuration;

namespace RCT
{
    public class BlockConnectionPoints
    {
        public Vector3 localStartPosition;
        public Vector3 localStartEuler;
        public Vector3 localEndPosition;
        public Vector3 localEndEuler;
        public bool valid = false;

        public BlockConnectionPoints() { }

        public BlockConnectionPoints(Vector3 _localStartPosition, Vector3 _localStartEuler, Vector3 _localEndPosition, Vector3 _localEndEuler)
        {
            localStartPosition = _localStartPosition;
            localStartEuler = _localStartEuler;
            localEndPosition = _localEndPosition;
            localEndEuler = _localEndEuler;
            valid = true;
        }
    }

    public class RCTBlock : MonoBehaviour
    {
        public int blockID;
        public BlockConnectionPoints connectionPoints;
        public Transform start;
        public Transform end;
    }

    public static class ConnectionData
    {
        private static Dictionary<int, BlockConnectionPoints> connectionData = new Dictionary<int, BlockConnectionPoints>()
        {
            //Single straight
            { 56, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend
            { 58, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend
            { 59, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend
            { 60, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open top)
            { 116, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },

            //Single straight (open top)
            { 227, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend (open top)
            { 228, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend (open top)
            { 229, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend (open top)
            { 230, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open top)
            { 231, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },

            //Single straight (open side)
            { 257, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //1x1 bend (open side)
            { 258, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) },
            //2x2 bend (open side)
            { 259, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,4f, 16f), new Vector3(0, -90f, 0)) },
            //3x3 bend (open side)
            { 260, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,4f, 32f), new Vector3(0, -90f, 0)) },
            //4x4 bend (open side)
            { 261, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,4f, 48f), new Vector3(0, -90f, 0)) },

            //Barrel roll
            { 248, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,40f), Vector3.zero) },

            //Folder 203
             { 110, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 61, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 62, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 63, new BlockConnectionPoints( new Vector3(0,4f,8f), new Vector3(0,180f,0), new Vector3(0,20f,-8f), new Vector3(0,180f,0)) },
             { 114, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 115, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 112, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 111, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 113, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
             { 1239, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1240, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1238, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1237, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1234, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 1235, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1236, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
             { 336, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 335, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

             //Folder 204
             { 117, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0)) },
             { 118, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
             { 119, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
             { 120, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0)) },
             { 121, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0)) },
             { 122, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0)) },
             { 123, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0)) },

             //Folder 205
             { 232, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 236, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 234, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 240, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
             { 237, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 238, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 235, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 233, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 239, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
             { 1246, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1247, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1245, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1244, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1241, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 1242, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1243, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },

             { 337, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 338, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

             { 249, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,0f), new Vector3(-90f, 0, 0)) },
             { 250, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,16f), new Vector3(-90f, 0, 0)) },
             { 251, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,44f,32f), new Vector3(-90f, 0, 0)) },
             { 252, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,60f,48f), new Vector3(-90f, 0, 0)) },

             { 253, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-4f,0f), new Vector3(90f, 0, 0)) },
             { 254, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-20f,16f), new Vector3(90f, 0, 0)) },
             { 255, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-36f,32f), new Vector3(90f, 0, 0)) },
             { 256, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,-52f,48f), new Vector3(90f, 0, 0)) },

            //Folder 206
             { 244, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0)) },
             { 241, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
             { 242, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
             { 243, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0)) },
             { 245, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0)) },
             { 246, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0)) },
             { 247, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0)) },

            //Folder 207
             { 262, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 266, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 264, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,24f), Vector3.zero) },
             { 270, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,8f), Vector3.zero) },
             { 267, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 268, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,28f,24f), Vector3.zero) },
             { 265, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 263, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 269, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,8f), Vector3.zero) },
             { 1253, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1254, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,20f,40f), Vector3.zero) },
             { 1252, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1251, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1248, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
             { 1249, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 1250, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,56f), Vector3.zero) },
             { 339, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },
             { 340, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,40f), Vector3.zero) },

            //Folder 208
             { 274, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-48f,-4f,-8f), new Vector3(0,180f,0)) },
             { 271, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-4f,16f), new Vector3(0,-90f,0)) },
             { 272, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-4f,32f), new Vector3(0,-90f,0)) },
             { 273, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-4f, 48f), new Vector3(0,-90f,0)) },
             { 275, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-24f,-12f,16f), new Vector3(0,-90f,0)) },
             { 276, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-40f,-20f,32f), new Vector3(0,-90f,0)) },
             { 277, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-56f,-28f, 48f), new Vector3(0,-90f,0)) },

            //Folder 209
            { 1547, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 1548, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            //{ 1549, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            //{ 1550, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            { 1551, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) }
            //{ 1552, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,56f), Vector3.zero) }
            //{ 1553, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) },
            //{ 1554, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,12f,24f), Vector3.zero) }

        };

        public static BlockConnectionPoints GetBlockConnectionPoints(int blockID)
        {
            if (connectionData.ContainsKey(blockID))
            {
                return connectionData[blockID];
            }

            return new BlockConnectionPoints();
        }

        public static bool Supports(int blockID)
        {
            return connectionData.ContainsKey(blockID);
        }
    }

    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.rct";
        public const string pluginName = "RCT";
        public const string pluginVersion = "1.0";
        public LEV_LevelEditorCentral central;

        public static Plugin Instance;

        public Material rctMaterial;

        public bool rctMode = false;

        public Vector3 startingPosition = Vector3.zero;

        private Rect windowRect = new Rect(20, 20, 250, 300);

        public ConfigEntry<KeyCode> rctButton;

        public void Awake()
        {
            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();

            Instance = this;

            rctButton = Config.Bind("Controls", "Toggle RCT Mode", KeyCode.Keypad0, "Toggle RCT Mode");
        }

        public void OnLevelEditor()
        {
            rctMaterial = MaterialManager.AllMaterials[100].material;
            rctMode = false;
            blockChain.Clear();
        }

        public RCTBlock CreateRCTBlock(int id, Material material, Vector3 pos)
        {
            BlockConnectionPoints connections = ConnectionData.GetBlockConnectionPoints(id);
            if (!connections.valid)
            {
                return null;
            }

            BlockProperties blockProperties = Object.Instantiate<BlockProperties>(PlayerManager.Instance.loader.globalBlockList.blocks[id]);
            blockProperties.CreateBlock();
            for (int index = 0; index < blockProperties.propertyScripts.Count; ++index)
            {
                blockProperties.propertyScripts[index].CreateBlock(blockProperties);
            }

            Properties_RoadPainter component = blockProperties.gameObject.GetComponent<Properties_RoadPainter>();
            foreach (MeshRenderer ren in component.renderers)
            {
                Material[] sharedMaterials = ren.sharedMaterials;
                for (int i = 0; i < sharedMaterials.Length; ++i)
                {
                    sharedMaterials[i] = material;
                }
                ren.sharedMaterials = sharedMaterials;
            }

            GameObject block = blockProperties.gameObject;
            RemoveUnwantedComponents(block);
            RCTBlock rct = block.AddComponent<RCTBlock>();

            GameObject start = new GameObject("Start");// GameObject.CreatePrimitive(PrimitiveType.Cube);
            start.transform.parent = block.transform;
            start.transform.localPosition = connections.localStartPosition;
            start.transform.localEulerAngles = connections.localStartEuler;
            start.gameObject.name = "Start";
            rct.start = start.transform;

            GameObject end = new GameObject("End");// GameObject.CreatePrimitive(PrimitiveType.Cube);
            end.transform.parent = block.transform;
            end.transform.localPosition = connections.localEndPosition;
            end.transform.localEulerAngles = connections.localEndEuler;
            end.gameObject.name = "End";
            rct.end = end.transform;

            rct.blockID = id;

            block.transform.position = pos;
            return rct;
        }

        void AlignTube(Transform previousEndTransform, Transform newTubeTransform, Transform newTubeStartTransform)
        {
            // Adjust rotation
            newTubeTransform.rotation = previousEndTransform.rotation * Quaternion.Inverse(newTubeStartTransform.localRotation);

            // Adjust position
            Vector3 offset = newTubeTransform.rotation * newTubeStartTransform.localPosition;
            newTubeTransform.position = previousEndTransform.position - offset;
        }

        void RotateTubeAroundStart(Transform newTubeTransform, Transform previousEndTransform, float angle)
        {
            // The pivot point is the overlapping point (previous tube's End transform position)
            Vector3 pivotPoint = previousEndTransform.position;

            // The rotation axis is the z-axis of the overlapping point
            Vector3 rotationAxis = previousEndTransform.forward;

            // Rotate the new tube around the pivot point and axis
            newTubeTransform.RotateAround(pivotPoint, rotationAxis, angle);
        }

        public List<RCTBlock> blockChain = new List<RCTBlock>();

        public void Update()
        {
            if(central == null)
            {
                rctMode = false;
                return;
            }

            if (Input.GetKeyDown(rctButton.Value))
            {
                if (rctMode)
                {
                    rctMode = false;
                    PlayerManager.Instance.messenger.Log("RCT MODE: OFF", 1f);
                }
                else
                {
                    if (central.selection.list.Count == 1)
                    {
                        if (central.selection.list[0].blockID == 1329)
                        {
                            rctMode = true;
                            startingPosition = central.selection.list[0].transform.position;

                            central.selection.DeselectAllBlocks(false, "");

                            PlayerManager.Instance.messenger.Log("RCT MODE: ON", 1f);
                        }
                        else
                        {
                            PlayerManager.Instance.messenger.Log("Select a single pivot and press the button to start RCT mode!", 3f);
                        }
                    }
                    else
                    {
                        PlayerManager.Instance.messenger.Log("Select a single pivot and press the button to start RCT mode!", 3f);
                    }
                }                
            }

            if (rctMode)
            {
                RotateLastPieceWithScroll();
            }

            /*
            if(rctMode)
            {
                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    DeleteChain();
                }

                if (Input.GetKeyDown(KeyCode.Keypad2))
                {
                    SolidifyChain();
                    DeleteChain();
                }

                if (Input.GetKeyDown(KeyCode.Keypad3))
                {
                    Undo();
                }                

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Flip();
                }

                if (Input.GetKeyDown(KeyCode.N))
                {
                    Reverse();
                }

                RotateLastPieceWithScroll();
            }*/
        }

        // Add the OnGUI method
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
                DeleteChain();
            }

            if (GUILayout.Button("Undo"))
            {
                Undo();
            }

            if (GUILayout.Button("Flip"))
            {
                Flip();
            }

            if (GUILayout.Button("Reverse"))
            {
                Reverse();
            }

            GUILayout.EndVertical();

            // Make the window draggable
            GUI.DragWindow();
        }

        public void Flip()
        {
            if (blockChain.Count > 0)
            {
                Transform b = blockChain[blockChain.Count - 1].transform;
                b.localScale = new Vector3(-b.localScale.x, b.localScale.y, b.localScale.z);

                if (blockChain.Count > 1)
                {
                    AlignTube(blockChain[blockChain.Count - 2].end, blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 1].start);
                }
            }
        }

        public void Reverse()
        {
            if (blockChain.Count > 0)
            {
                //Switch the start and end
                RCTBlock last = blockChain[blockChain.Count - 1];
                Transform temp = last.start;
                last.start = last.end;
                last.end = temp;

                //Rotate both around the z-axis
                last.start.Rotate(0, 180, 0);
                last.end.Rotate(0, 180, 0);

                if (blockChain.Count > 1)
                {
                    AlignTube(blockChain[blockChain.Count - 2].end, blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 1].start);
                }
            }
        }

        public void Undo()
        {
            if (blockChain.Count > 0)
            {
                //Destroy and remove
                GameObject.Destroy(blockChain[blockChain.Count - 1].gameObject);

                blockChain.RemoveAt(blockChain.Count - 1);
            }
        }

        public void SolidifyChain()
        {
            central.selection.DeselectAllBlocks(true, "");

            if (blockChain.Count > 0)
            {
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
            }
        }

        public void DeleteChain()
        {
            foreach (RCTBlock b in blockChain)
            {
                GameObject.Destroy(b.gameObject);
            }

            blockChain.Clear();
        }

        public void RotateLastPieceWithScroll()
        {
            if(!central.cam.IsCursorInGameView())
            {
                return;
            }

            if (blockChain.Count > 1)
            {
                float rValue = central.gizmos.list_gridR[central.gizmos.index_gridR];
                if (Input.mouseScrollDelta.y > 0)
                {
                    RotateTubeAroundStart(blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 2].end, rValue);
                }
                else if (Input.mouseScrollDelta.y < 0)
                {
                    RotateTubeAroundStart(blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 2].end, -rValue);
                }
            }
        }

        public void NextBlock(int id)
        {
            if (!ConnectionData.Supports(id))
            {
                PlayerManager.Instance.messenger.Log("Unsupported :(", 1f);
                return;
            }

            RCTBlock block = CreateRCTBlock(id, rctMaterial, startingPosition);
            blockChain.Add(block);
            if (blockChain.Count > 1)
            {
                AlignTube(blockChain[blockChain.Count - 2].end, blockChain[blockChain.Count - 1].transform, blockChain[blockChain.Count - 1].start);
            }
        }

        public static void RemoveUnwantedComponents(GameObject target)
        {
            // Array of types to keep
            System.Type[] typesToKeep = { typeof(Transform), typeof(MeshFilter), typeof(MeshRenderer) };

            // Get all components in target and its children
            foreach (Transform child in target.GetComponentsInChildren<Transform>(true))
            {
                // Get all components attached to this GameObject
                Component[] components = child.GetComponents<Component>();

                foreach (Component component in components)
                {
                    // Check if the component is not in the typesToKeep array
                    bool shouldKeep = false;
                    foreach (var type in typesToKeep)
                    {
                        if (component.GetType() == type)
                        {
                            shouldKeep = true;
                            break;
                        }
                    }

                    // If the component should not be kept, destroy it
                    if (!shouldKeep)
                    {
                        Object.DestroyImmediate(component);
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(LEV_LevelEditorCentral), "Awake")]
    public class LEVLevelEditorCentralAwakePatch
    {
        public static void Postfix(LEV_LevelEditorCentral __instance)
        {
            Plugin.Instance.central = __instance;
            Plugin.Instance.OnLevelEditor();
        }
    }

    [HarmonyPatch(typeof(LEV_GizmoHandler), "CreateNewBlock")]
    public class LEVGizmoHandlerCreateNewBlock
    {
        public static bool Prefix(ref int blockID)
        {
            if (Plugin.Instance.rctMode)
            {
                Plugin.Instance.NextBlock(blockID);
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}