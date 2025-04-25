/* ambigous match error ill fix later
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Synthium.Backend.ConsoleLibrary;
using UnityEngine;

namespace Synthium.Backend.Patches
{
    
    [HarmonyPatch(typeof(NetworkSystemRaiseEvent), "RaiseEvent")]
    [HarmonyPatch(new[] { typeof(byte[]), typeof(object), typeof(NetEventOptions), typeof(bool) })]
    class EventInformer
    {
        private static void Postfix(byte code, object data, NetEventOptions options, bool reliable)
        {
            if (code == 8)
            {
                //OMG explicit cast
                object[] reportInfo = (object[])data;
                OverrideConsole.EasyWrite($"A report has been sent.\nRoomStringStripped: {reportInfo[0]}\nSuspicious Player ID: {reportInfo[3]}\nNickname: {reportInfo[4]}\nReason:{reportInfo[5]} ");
            }
        }
    }
}*/
