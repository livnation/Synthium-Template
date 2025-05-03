using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Synthium.Backend.Patches
{
    
    [BepInPlugin("synthium.gg", "Synthium Template", "0.0.1")]
    public class Plugin : BaseUnityPlugin
    {
        private void Start()
        {
            new Harmony("synthium").PatchAll();
            GameObject loader = new GameObject("SynthiumObj");
            loader.AddComponent<Synthium.WristMenu.PhysicalMenu>();
            DontDestroyOnLoad(loader);
        }
    }
}