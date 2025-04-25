using System;
using HarmonyLib;
using BepInEx;
using System.Runtime.InteropServices;
using UnityEngine;
using System.IO;

namespace Synthium.Backend.ConsoleLibrary
{
    [BepInPlugin("synthium.debugger", "Synthium Debugger", "0.0.1")]
    internal class OverrideConsole : BaseUnityPlugin
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr AllocConsole();
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool Write(IntPtr hConsoleOutput, string lpBuffer, uint nNumberOfCharsToWrite, out uint lpNumberOfCharsWritten, IntPtr lpReserved);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();

        void Start()
        {
            AllocConsole();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Console.WriteLine($"[Synthium] Console started at {DateTime.Now:T}");
        }

        public static void EasyWrite(string message)
        {
            Console.WriteLine($"[Synthium] {message}");
        }
    }
}
