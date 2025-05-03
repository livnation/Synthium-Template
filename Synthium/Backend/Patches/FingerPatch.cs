using HarmonyLib;

namespace Synthium.Backend.Patches
{
    // blocks finger input without breaking any mods 😁
    [HarmonyPatch(typeof(VRMap), "MapMyFinger")]
    internal class FingerPatch1
    {
        public static bool fingersEnabled = false;
        static bool Prefix(float lerpValue) => fingersEnabled;
    }
    [HarmonyPatch(typeof(VRMapIndex), "MapMyFinger")]
    internal class FingerPatch2
    {
        static bool Prefix(float lerpValue) => FingerPatch1.fingersEnabled;
    }
    [HarmonyPatch(typeof(VRMapMiddle), "MapMyFinger")]
    internal class FingerPatch3
    {
        static bool Prefix(float lerpValue) => FingerPatch1.fingersEnabled;
    }
    [HarmonyPatch(typeof(VRMapThumb), "MapMyFinger")]
    internal class FingerPatch4
    {
        static bool Prefix(float lerpValue) => FingerPatch1.fingersEnabled;
    }

}
