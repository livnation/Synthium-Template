using HarmonyLib;
using PlayFab.Internal;
using PlayFab;
using UnityEngine;

namespace Synthium.Backend.Patches
{
    internal class PlayfabPatch : MonoBehaviour
    {
        [HarmonyPatch(typeof(PlayFabDeviceUtil), "SendDeviceInfoToPlayFab")]
        private static class SendInfo
        {
            static bool Prefix() => false;
        }

        [HarmonyPatch(typeof(PlayFabClientInstanceAPI), "ReportDeviceInfo")]
        private static class ReportInstanceInfo
        {
            static bool Prefix() => false;
        }

        [HarmonyPatch(typeof(PlayFabClientAPI), "ReportDeviceInfo")]
        private static class ReportClientInfo
        {
            static bool Prefix() => false;
        }

        [HarmonyPatch(typeof(PlayFabDeviceUtil), "GetAdvertIdFromUnity")]
        private static class AdvertID
        {
            static bool Prefix() => false;
        }

        [HarmonyPatch(typeof(PlayFabClientAPI), "AttributeInstall")]
        private static class AttrInstall
        {
            static bool Prefix() => false;
        }

        [HarmonyPatch(typeof(PlayFabHttp), "InitializeScreenTimeTracker")]
        private static class ISTT
        {
            static bool Prefix() => false;
        }
    }
}   
