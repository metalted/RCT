using BepInEx;
using HarmonyLib;

namespace ZeepkistPluginBase
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGUID = "com.metalted.zeepkist.rct";
        public const string pluginName = "RCT";
        public const string pluginVersion = "1.0";

        public void Awake()
        {
            Harmony harmony = new Harmony(pluginGUID);
            harmony.PatchAll();
        }
    }        
}
