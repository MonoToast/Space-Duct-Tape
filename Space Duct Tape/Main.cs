using BepInEx;
using HarmonyLib;
using LaunchPadBooster;

namespace Space_Duct_Tape
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        public const string GUID = "com.monotoast.Space_Duct_Tape";
        public const string NAME = "Space_Duct_Tape";
        public const string VERSION = "1.0.0";

        private Harmony _harmony;
        private Mod _mod;

        private void Awake()
        {
            Logger.LogInfo($"{NAME} v{VERSION} is loading...");

            _mod = new Mod(NAME, VERSION);
            _harmony = new Harmony(GUID);

            try
            {
                _harmony.PatchAll();
                Logger.LogInfo($"{NAME} patches applied successfully.");
            }
            catch (System.Exception ex)
            {
                Logger.LogError($"Error patching: {ex}");
            }

            Logger.LogInfo($"{NAME} v{VERSION} has loaded.");
        }

        private void OnDestroy()
        {
            try
            {
                _harmony?.UnpatchSelf();
                Logger.LogInfo($"{NAME} patches have been removed.");
            }
            catch (System.Exception ex)
            {
                Logger.LogError($"Error unpatching: {ex}");
            }
        }
    }
}
