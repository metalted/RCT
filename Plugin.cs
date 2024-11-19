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
        public const string pluginVersion = "1.5";       

        public static Plugin Instance;        

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

            GUIStyleX.Initialize();
            RCTManager.Initialize();
        }

        public void Update()
        {
            RCTManager.DoUpdate();
        }

        private void OnGUI()
        {
            RCTManager.DoGUI();
        }   
    }

    [HarmonyPatch(typeof(LEV_LevelEditorCentral), "Awake")]
    public class LEVLevelEditorCentralAwakePatch
    {
        public static void Postfix(LEV_LevelEditorCentral __instance)
        {
            RCTManager.OnLevelEditor(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_GizmoHandler), "CreateNewBlock")]
    public class LEVGizmoHandlerCreateNewBlockPatch
    {
        public static bool Prefix(ref int blockID)
        {
            if (RCTManager.IsEnabled())
            {
                RCTManager.BlockSelectedInBlockGUI(blockID);
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
            RCTManager.OnNotLevelEditor();
        }
    }

    [HarmonyPatch(typeof(SetupGame), "Awake")]
    public class SetupGameAwakePatch
    {
        public static void Postfix()
        {
            RCTManager.OnNotLevelEditor();
        }
    }
}