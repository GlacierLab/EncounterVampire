using HarmonyLib;
using Live2D.Cubism.Framework.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
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
        static bool Start1()
        {
            Plugin.MenuLoaded = true;
            Plugin.Log.LogInfo(new System.Diagnostics.StackTrace(true).ToString());
            Plugin.Log.LogInfo("No Fullscreen Switch!");
            return false;
        }

    }
}
