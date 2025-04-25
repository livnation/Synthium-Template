using System;
using HarmonyLib;
using UnityEngine;

namespace Synthium.Backend.Patches
{
    [HarmonyPatch(typeof(GameObject))]
    [HarmonyPatch("CreatePrimitive")]
    internal class Shaders : MonoBehaviour
    {
        private static void Postfix(GameObject __result)
        {
            __result.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
        }
    }
}
