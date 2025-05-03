using GorillaLocomotion;
using UnityEngine;

namespace Synthium.WristMenu.Mods
{
    public class Movement
    {
        static GameObject Air1 = null;
        static GameObject Air2 = null;
        public static void AirJump()
        {
            HandleAirJump(ref Air1, ControllerInputPoller.instance.rightGrab, GorillaTagger.Instance.rightHandTransform);
            HandleAirJump(ref Air2, ControllerInputPoller.instance.leftGrab, GorillaTagger.Instance.leftHandTransform);
        }
        
        private static void HandleAirJump(ref GameObject platform, bool isGrabbed, Transform handTransform)
        {
            if (isGrabbed && platform == null)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.transform.localScale = new Vector3(0.02f, 0.12f, 0.18f);
                var renderer = platform.GetComponent<MeshRenderer>();
                platform.transform.SetPositionAndRotation(handTransform.position, handTransform.rotation);
                platform.AddComponent<Backend.MenuComponents.ColorLerp>().Initialize(renderer, Color.black, Color.grey, 1f, true);
            }
            else if (!isGrabbed && platform)
            {
                CleanupObject(ref platform);
            }
        }

        public static void CleanupObject(ref GameObject obj)
        {
            GameObject.Destroy(obj);
            obj = null;
        }
        
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GTPlayer.Instance.headCollider.transform.forward * 2f;
            }
        }
    }
}