using System;
using System.Linq;
using BepInEx;
using GorillaLocomotion;
using HarmonyLib;
using Oculus.Interaction.Input;
using Photon.Pun;
using Photon.Realtime;
using Synthium.Backend.ConsoleLibrary;
using Synthium.Backend.MenuComponents;
using UnityEngine;
using UnityEngine.UI;
using Button = Synthium.Backend.MenuComponents.Button;
using Object = UnityEngine.Object;

namespace Synthium.WristMenu
{
    [HarmonyPatch(typeof(GTPlayer), "LateUpdate")]
    internal class PhysicalMenu : MonoBehaviour
    {
        public static GameObject menu, baseMenu, canvasObj, clicker;
        private static int pageIndex;
        public static int categoryIndex;
        public static SphereCollider clickerCollider;


        public static void Prefix()
        {
            try
            {
                if (menu == null && ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    Draw();
                }
                else if (menu != null && !ControllerInputPoller.instance.leftControllerPrimaryButton)
                {
                    DestroyMenu(false);
                }

                foreach (Button[] btns in ButtonList.Buttons)
                {
                    foreach (Button btn in btns)
                    {
                        if (btn.enabled && btn.enableMethod != null)
                        {
                            btn.enableMethod.Invoke();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log($"error in prefix: {e.ToString()} stack trace: {e.StackTrace} source: {e.Source}");
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
            baseMenu.transform.SetPositionAndRotation(hand.position + hand.right * 0.07f + hand.up * 0.03f,
                hand.rotation);
            clicker.transform.localPosition = new Vector3(0f, -0.1f, 0f);
        }

        public static void CreateClicker()
        {
            clicker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            clicker.name = "SynthiumClicker";
            clicker.transform.parent = GorillaTagger.Instance.rightHandTransform;
            clicker.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            clicker.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            clicker.GetComponent<Renderer>().enabled = true;
            clicker.GetComponent<MeshRenderer>().material.color = Color.white;
            UnityEngine.Object.Destroy(clicker.GetComponent<Collider>());
            UnityEngine.Object.Destroy(clicker.GetComponent<Rigidbody>());
            clickerCollider = clicker.AddComponent<SphereCollider>();
            clickerCollider.isTrigger = true;
        }

        public static void Draw()
        {
            baseMenu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foreach (var obj in new[] { baseMenu, menu })
            {
                UnityEngine.Object.Destroy(obj.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(obj.GetComponent<Collider>());
            }

            UnityEngine.Object.Destroy(baseMenu.GetComponent<Renderer>());

            baseMenu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);
            menu.transform.SetParent(baseMenu.transform);
            menu.transform.localPosition = Vector3.zero;
            menu.transform.localRotation = Quaternion.identity;
            menu.transform.localScale = new Vector3(0.1f, 1.1f, 0.8f);
            canvasObj = new GameObject();
            canvasObj.transform.parent = menu.transform;
            var canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasObj.AddComponent<CanvasScaler>().dynamicPixelsPerUnit = 2000f;
            canvasObj.AddComponent<GraphicRaycaster>();

            var text = new GameObject().AddComponent<Text>();
            text.transform.parent = canvasObj.transform;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = "kante menu v0.1\n";
            text.fontSize = 1;
            text.color = Color.white;
            text.supportRichText = true;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            var rect = text.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(0.6f, 0.03f);
            rect.localPosition = new Vector3(0.008f, -0.253f, 0.13f);
            rect.localRotation = Quaternion.Euler(180f, 90f, 90f);
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            mat.color = new Color(0.05f, 0.05f, 0.05f);
            menu.GetComponent<MeshRenderer>().material = mat;
            menu.GetComponent<MeshRenderer>().material.color = Color.black;
            /*var start = GetHex("#000000");
            var end = GetHex("#0d0c0c");
            Backend.MenuComponents.Gradient.AddGradientComponent(menu, start, end, 1f);*/
            var activeButtons = ButtonList.Buttons[categoryIndex].Skip(pageIndex * 7).Take(7).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
                CreateButtons(activeButtons[i], i * 0.1f);
            CreatePageButtons();
            CreateClicker();
        }

        public static void CreateButtons(Button btn, float offset)
        {
            var button = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(button.GetComponent<Rigidbody>());
            button.name = "SynthiumButton";
            var collider = button.GetComponent<Collider>() as BoxCollider ?? button.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            button.transform.parent = baseMenu.transform;
            button.transform.localPosition = new Vector3(0.1f, 0f, 0.28f - offset);
            button.transform.localRotation = Quaternion.identity;
            button.transform.localScale = new Vector3(0.0001f, 0.98f, 0.093f);
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            mat.color = new Color(0.05f, 0.05f, 0.05f);
            mat.SetFloat("_Metallic", 0.6f);
            mat.SetFloat("_Smoothness", 0.1f);
            button.GetComponent<MeshRenderer>().material = mat;
            button.GetComponent<MeshRenderer>().material.color = Color.black;
            var trigger = button.AddComponent<ButtonCollider>();
            trigger.text = btn.buttonText;
            var text = new GameObject().AddComponent<Text>();
            text.transform.parent = canvasObj.transform;
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = btn.buttonText;
            text.color = btn.enabled ? GetHex("#181a1c") : Color.white;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            var rect = text.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(0.15f, 0.03f);
            rect.localPosition = new Vector3(0.011f, -0.0077f, 0.1098f - offset / 2.6f);
            rect.localRotation = Quaternion.Euler(180f, 90f, 90f);
        }

        public static void CreatePageButtons()
        {
            var button = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(button.GetComponent<Rigidbody>());
            button.name = "SynthiumButton";
            var collider = button.GetComponent<Collider>() as BoxCollider ?? button.AddComponent<BoxCollider>();
            collider.isTrigger = true;
            button.transform.parent = baseMenu.transform;
            button.transform.localPosition = new Vector3(0.0008f, 0.4f, -0.38f);
            button.transform.localRotation = Quaternion.identity;
            button.transform.localScale = new Vector3(0.001f, 0.27f, 0.14f);
            var trigger = button.AddComponent<ButtonCollider>();
            trigger.text = "prev";
            var button2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(button2.GetComponent<Rigidbody>());
            button2.name = "SynthiumButton";
            var collider2 = button2.GetComponent<Collider>() as BoxCollider ?? button2.AddComponent<BoxCollider>();
            collider2.isTrigger = true;
            button2.transform.parent = baseMenu.transform;
            button2.transform.localPosition = new Vector3(0.0008f, -0.38f, -0.38f);
            button2.transform.localRotation = Quaternion.identity;
            button2.transform.localScale = new Vector3(0.001f, 0.27f, 0.14f);
            button.GetComponent<MeshRenderer>().enabled = false;
            button2.GetComponent<MeshRenderer>().enabled = false;

            var trigger2 = button2.AddComponent<ButtonCollider>();
            trigger2.text = "next";
        }

        public static Button GetButton(string text)
        {
            foreach (var btnArray in ButtonList.Buttons)
            foreach (var btn in btnArray)
                if (btn.buttonText == text)
                    return btn;
            return null;
        }
        
        public static void DestroyMenu(bool redraw)
        {
            UnityEngine.Object.Destroy(menu);
            UnityEngine.Object.Destroy(baseMenu);
            UnityEngine.Object.Destroy(clicker);
            menu = baseMenu = null;
            if (redraw) Draw();
        }

        public static void ToggleButton(string btnText)
        {
            var pageLength = ButtonList.Buttons.Length;
            if (btnText == "next")
            {
                pageIndex = (pageIndex + 1) % pageLength;
                DestroyMenu(true);
                return;
            }

            if (btnText == "prev")
            {
                pageIndex = (pageIndex - 1 + pageLength) % pageLength;
                DestroyMenu(true);
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

            DestroyMenu(true);
        }
    }
}