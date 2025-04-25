using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace Synthium.Backend.Patches
{
    internal class PreventLocalReporting : MonoBehaviour
    {
        [HarmonyPatch(typeof(GorillaNot), "SendReport")]
        static class SRP
        {
            static bool Prefix(ref string susReason, ref string susId, ref string susNick) => false;
        }
        [HarmonyPatch(typeof(GorillaNot), "CheckReports")]
        static class CRP
        {
            static bool Prefix() => false;
        }
        [HarmonyPatch(typeof(GorillaNot), "DispatchReport")]
        static class DRP
        {
            static bool Prefix() => false;
        }
    }
}
