using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BepInEx.Configuration;
using ZeepSDK.UI;

namespace RCT
{      
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    [BepInDependency("ZeepSDK", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.metalted.zeepkist.toolkist", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.rct";
        public const string pluginName = "RCT";
        public const string pluginVersion = "2.0";       

        public static Plugin Instance;        

        //Settings
        public ConfigEntry<KeyCode> undoButton;
        public ConfigEntry<KeyCode> flipButton;
        public ConfigEntry<KeyCode> reverseButton;
        public ConfigEntry<KeyCode> resetRotationButton;

        public ConfigEntry<int> rctBlockID;
        public ConfigEntry<bool> visualizeConnectPoints;

        public RCTUIHandler UIHandler { get; private set; }
        public RCTManager RCTManager { get; private set; }
        private RCTToolbarDrawer _toolbarDrawer;
        private RCTGUIDrawer _drawer;

        private Color rctColor = new Color(0.294f, 0.047f, 0.659f);

        public void Awake()
        {
            Instance = this;

            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();

            //Preferences
            undoButton = Config.Bind("Controls", "Undo Button Shortcut", KeyCode.None, "Optional control to press the Undo button with a keyboard key.");
            flipButton = Config.Bind("Controls", "Flip Button Shortcut", KeyCode.None, "Optional control to press the Flip button with a keyboard key.");
            reverseButton = Config.Bind("Controls", "Reverse Button Shortcut", KeyCode.None, "Optional control to press the Reverse button with a keyboard key.");

            rctBlockID = Config.Bind("Preferences", "RCT Block ID", 69, "The block that will be used to configure the start position and rotation of the chain.");
            visualizeConnectPoints = Config.Bind("Preferences", "Show connection points", false, "Visualizes the connection points configured in the plugin. Mostly used for debugging purposes.");

            UIHandler = new RCTUIHandler();
            RCTManager = new RCTManager();

            _toolbarDrawer = new RCTToolbarDrawer(this, RCTManager, UIHandler);
            UIApi.AddToolbarDrawer(_toolbarDrawer);
            _drawer = new RCTGUIDrawer(this, RCTManager, UIHandler);
            UIApi.AddZeepGUIDrawer(_drawer);

            Logger.LogInfo($"Plugin {pluginName} is loaded!");
        }

        private void OnDestroy()
        {
            RCTManager?.Dispose();

            UIApi.RemoveToolbarDrawer(_toolbarDrawer);
            UIApi.RemoveZeepGUIDrawer(_drawer);
        }

        public void Update()
        {
            RCTManager.OnUpdate();
        }

        public void LogScreenMessage(string msg, float time)
        {
            PlayerManager.Instance.messenger.LogCustomColor(msg, time, Color.white, rctColor);
        }
    }

    [HarmonyPatch(typeof(LEV_LevelEditorCentral), "Awake")]
    public class LEVLevelEditorCentralAwakePatch
    {
        public static void Postfix(LEV_LevelEditorCentral __instance)
        {
            Plugin.Instance.RCTManager.EnteredLevelEditor(__instance);
        }
    }

    [HarmonyPatch(typeof(LEV_GizmoHandler), "CreateNewBlock")]
    public class LEVGizmoHandlerCreateNewBlockPatch
    {
        public static bool Prefix(ref int blockID)
        {
            if (Plugin.Instance.RCTManager.rctModeActive && Plugin.Instance.RCTManager.chainStarted)
            {
                Plugin.Instance.RCTManager.BlockSelectedInBlockGUI(blockID);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}