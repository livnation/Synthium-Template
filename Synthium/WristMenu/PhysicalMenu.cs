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
using Button = Synthium.Backend.MenuComponents.Button;
using static Fusion.Sockets.NetBitBuffer;

namespace Synthium.WristMenu
{
    [HarmonyPatch(typeof(GTPlayer), "LateUpdate")]
    internal class PhysicalMenu : MonoBehaviour
    {
        public static GameObject menu;
        public static GameObject baseMenu;
        public static GameObject canvasObj;
        private static int pageIndex;
        public static void Prefix()
        {
            try
            {
                //if (ControllerInputPoller.instance.leftControllerPrimaryButton)
                //{
                if (!menu) Draw();
                //}
                //else
                //{
                //DestroyMenu(false);
                //}
            }
            catch (Exception e)
            {
                OverrideConsole.EasyWrite($"Error: {e.Message}");
            }
            try
            {
                foreach (Button[] buttons in ButtonList.Buttons)
                {
                    foreach (Button button in buttons)
                    {
                        if (button.enabled)
                        {
                            button.enableMethod.Invoke();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                OverrideConsole.EasyWrite($"Error: {e.Message}");
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
            baseMenu.transform.SetPositionAndRotation(hand.position + hand.right * 0.07f, hand.rotation);
        }

        public static void Nigger()
        {
            UnityEngine.Object.FindObjectOfType<CrittersFood>().SpawnData(999, 999, 25f);
        }

        public static void Draw()
        {
            baseMenu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foreach (var obj in new[] { baseMenu, menu })
            {
                UnityEngine.Object.Destroy(obj.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(obj.GetComponent<BoxCollider>());
                if (obj == baseMenu) UnityEngine.Object.Destroy(obj.GetComponent<Renderer>());
            }
            baseMenu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
            menu.transform.SetParent(baseMenu.transform);
            menu.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            menu.transform.localScale = new Vector3(0.1f, 1.1f, 1f);

            canvasObj = new GameObject { transform = { parent = menu.transform } };
            var canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasObj.AddComponent<CanvasScaler>().dynamicPixelsPerUnit = 2000f;
            canvasObj.AddComponent<GraphicRaycaster>();

            var text = new GameObject { transform = { parent = canvasObj.transform } }.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = "Synthium";
            text.fontSize = 1;
            text.color = Color.white;
            text.supportRichText = true;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;

            var rect = text.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.sizeDelta = new Vector2(0.6f, 0.03f);
            rect.SetPositionAndRotation(new Vector3(0.06f, 0f, 0.165f), Quaternion.Euler(180f, 90f, 90f));

            menu.GetComponent<MeshRenderer>().material.color = new Color32(12, 52, 94, 255);
        }

        public static void CreateButtons()
        {
            GameObject btn = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(btn.GetComponent<Rigidbody>());
            btn.GetComponent<BoxCollider>().isTrigger = true;
        }
        public static Button GetButton(string buttonText)
        {
            return ButtonList.Buttons.SelectMany(buttons => buttons).FirstOrDefault(button => button.buttonText == buttonText);
        }

        public static void DestroyMenu(bool redraw)
        {
            if (menu || baseMenu)
            {
                UnityEngine.Object.Destroy(menu);
                UnityEngine.Object.Destroy(baseMenu);
                menu = baseMenu = null;
            }
            if (redraw)
            {
                Draw();
            }
        }
        public static void ToggleButton(string btnText)
        {
            int pageLength = ButtonList.Buttons.Length;
            if (btnText == "next")
            {
                pageIndex = (pageIndex + 1) % pageLength;
                return;
            }
            if (btnText == "prev")
            {
                pageIndex = (pageIndex - 1 + pageLength) % pageLength;
                return;
            }
            var button = GetButton(btnText);
            if (button == null) return;
            if (button.toggle)
            {
                button.enabled = !button.enabled;
                (button.enabled ? button.enableMethod : button.disable)?.Invoke();
            }
            else
            {
                button.method.Invoke();
            }
        }
    }
}
