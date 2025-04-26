using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using GorillaLocomotion;
using HarmonyLib;
using Synthium.Backend.ConsoleLibrary;
using Synthium.Backend.MenuComponents;
using UnityEngine;
using UnityEngine.UI;
using static Fusion.Sockets.NetBitBuffer;

namespace Synthium.WristMenu
{
    [HarmonyPatch(typeof(GTPlayer), "LateUpdate")]
    internal class PhysicalMenu : MonoBehaviour
    {
        public static GameObject menu;
        public static GameObject baseMenu;
        public static GameObject canvasObj;
        public static void Prefix()
        {
            try
            {
                if (menu != null && ControllerInputPoller.instance.leftControllerPrimaryButton) return;
                Draw();
            }
            catch (Exception e)
            {
                OverrideConsole.EasyWrite("Error: " + e.Message);
            }
        }

        public static Color GetHex(string hexcode)
        {
            return ColorUtility.TryParseHtmlString(hexcode, out Color hexcolor) ? hexcolor : Color.white;
        }

        public void Update()
        {
            if (menu == null) return;
            var hand = GTPlayer.Instance.leftControllerTransform;
            baseMenu.transform.position = hand.position + (hand.forward * 0.26f) + (hand.right * 0.02f);
            baseMenu.transform.rotation = hand.rotation;
        }

        public static void Draw()
        {
            baseMenu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(baseMenu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(baseMenu.GetComponent<BoxCollider>());
            UnityEngine.Object.Destroy(baseMenu.GetComponent<Renderer>());
            baseMenu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
            menu.transform.SetParent(baseMenu.transform);
            menu.transform.rotation = Quaternion.identity;
            menu.transform.localScale = new Vector3(0.1f, 1.1f, 1f);
            menu.transform.position = Vector3.zero;
            canvasObj = new GameObject();
            canvasObj.transform.parent = menu.transform;
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 2000f;
            // just took text from old template, someone fix the positioning.
            Text text = new GameObject
            {
                transform =
                    {
                        parent = canvasObj.transform
                    }
            }.AddComponent<Text>();
            text.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
            text.text = "Synthium";
            text.fontSize = 1;
            text.color = Color.white;
            text.supportRichText = true;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.6f, 0.03f);
            component.position = new Vector3(0.06f, 0f, 0.154f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
        public static void CreateButtons(BaseMod mod)
        {
           
        }
    }
}
