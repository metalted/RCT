using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace RCT
{
    public struct BlockConnectionPoints
    {
        public Vector3 localStartPosition;
        public Vector3 localStartEuler;
        public Vector3 localEndPosition;
        public Vector3 localEndEuler;
        public bool valid = false;

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
    }    

    public static class ConnectionData
    {
        private static Dictionary<int, BlockConnectionPoints> connectionData = new Dictionary<int, BlockConnectionPoints>()
        {
            { 56, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(0,4f,8f), Vector3.zero) },
            { 58, new BlockConnectionPoints( new Vector3(0,4f,-8f), Vector3.zero, new Vector3(-8f,4f, 0f), new Vector3(0, -90f, 0)) }
        };

        public static BlockConnectionPoints GetBlockConnectionPoints(int blockID)
        {
            if(connectionData.ContainsKey(blockID))
            {
                return connectionData[blockID];
            }

            return new BlockConnectionPoints();
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
        public int singleTubeID = 56;
        public int tinyBendID = 58;
        public int normalBendID = 59;

        public Material rctMaterial;

        public void Awake()
        {
            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();

            Instance = this;
        }

        public void OnLevelEditor()
        {
            rctMaterial = MaterialManager.AllMaterials[100].material;
        }

        public RCTBlock CreateRCTBlock(int id, Material material, Vector3 pos)
        {
            BlockConnectionPoints connections = ConnectionData.GetBlockConnectionPoints(id);
            if(!connections.valid)
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

            GameObject start = GameObject.CreatePrimitive(PrimitiveType.Cube);
            start.transform.parent = block.transform;
            start.transform.localPosition = connections.localStartPosition;
            start.transform.localEulerAngles = connections.localStartEuler;

            GameObject end = GameObject.CreatePrimitive(PrimitiveType.Cube);
            end.transform.parent = block.transform;
            end.transform.localPosition = connections.localEndPosition;
            end.transform.localEulerAngles = connections.localEndEuler;

            block.transform.position = pos;
            return block.AddComponent<RCTBlock>();
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Keypad6))
            {
                CreateRCTBlock(singleTubeID, rctMaterial, new Vector3(64f, 32f, 32f));
            }

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
               CreateRCTBlock(tinyBendID, rctMaterial, new Vector3(32f,32f,32f));
            }

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                TryGoingIntoRCTMode();
            }
        }

        public void TryGoingIntoRCTMode()
        {
            if(central == null)
            {
                return;
            }

            //We can only have 1 object selected and it has to be a single tube for now
            if(central.selection.list.Count != 1)
            {
                return;
            }

            if (central.selection.list[0].blockID != singleTubeID)
            {
                return;
            }

            GoIntoRCTMode(central.selection.list[0]);
        }

        public void GoIntoRCTMode(BlockProperties startPiece)
        {

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

    //Target
    //We can select a <type> piece in the level editor.
    //By pressing a button we can activate RCT mode.
    //On the first piece selected we can still select the direction we want to go in, as there are 2.
    //We can now select pieces that connect to the previous piece from a menu.
    //By using the menu or the mouse wheel we can set the rotation of the next piece in relation to the previous piece.

    //First test
    //Place a single tube in the level editor
    //Select the tube
    //Press a button to enter RCT mode
    //Press button 1 to use a straight piece, no rotation.
    //Press button 2 to use a bend that can be rotated.
    //By pressing the button we add a piece to the chain, the last piece is always the one being edited.
    //Try rotating the piece.



    [HarmonyPatch(typeof(LEV_LevelEditorCentral), "Awake")]
    public class LEVLevelEditorCentralAwakePatch
    {
        public static void Postfix(LEV_LevelEditorCentral __instance)
        {
            Plugin.Instance.central = __instance;
            Plugin.Instance.OnLevelEditor();
        }
    }
}
