using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;


namespace Vampire2Framerate
{
    internal class Breach
    {
        static void Main(string[] args)
        {
        }

        //FPS Breach
        [HarmonyPatch(typeof(QualityCtrl), "SetFPS")]
        [HarmonyPrefix]
        static void SetFPS(int fpsIn)
        {
            Plugin.Log.LogInfo("FPS Breach Hits!");
            UnityEngine.QualitySettings.vSyncCount = 1;
            UnityEngine.Application.targetFrameRate = -1;
        }

        //Skip Loading
        [HarmonyPatch(typeof(LoadingBuffer), "Start")]
        [HarmonyPrefix]
        static void Start()
        {
            Plugin.Log.LogInfo("Skip Logo!");
            UnityEngine.SceneManagement.SceneManager.LoadScene("opentheme");
        }

        //Fix Fullscreen switch
        [HarmonyPatch(typeof(LoadingInit), "Start")]
        [HarmonyPrefix]
        static void Start1()
        {
            Plugin.Log.LogInfo("No Fullscreen Switch!");
        }

    }
}
