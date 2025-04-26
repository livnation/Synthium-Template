using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Harmony;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Synthium.WristMenu;

namespace Synthium.Backend.Patches
{
    [BepInPlugin("synthium.vin", "Synthium", "1.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Start()
        {
            new Harmony("synthiumproductions").PatchAll(Assembly.GetExecutingAssembly());
            GameObject go = new GameObject("SynthiumObj");
            go.AddComponent<PhysicalMenu>();
            DontDestroyOnLoad(go);
        }
    }
}
