using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

namespace Vampire2Framerate;

[BepInPlugin("qinlili.vampiresmelody2.fpsbreach", "Unlock FPS", "1.0.1.0")]
public class Plugin : BasePlugin
{
    public static new ManualLogSource Log;

    public static bool MenuLoaded = false;

    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin FPS Breach is loaded!");
        Log.LogInfo("Processing...");
        Harmony.CreateAndPatchAll(typeof(Breach));
        Log.LogInfo("Patched!"); 
        Task.Run(delegate
        {
            while (!MenuLoaded)
            {
                SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
            }
        });
    }

}
