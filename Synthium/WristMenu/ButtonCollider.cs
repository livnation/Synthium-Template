using System;
using UnityEngine;

namespace Synthium.WristMenu
{
    public class ButtonCollider : MonoBehaviour
    {
        public string text;
        public float delay;

        public void OnTriggerEnter(Collider collider)
        {
            if (collider == PhysicalMenu.clickerCollider && Time.time > delay)
            {
                PhysicalMenu.ToggleButton(text);
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(138, true, 0.25f);
                delay = Time.time + 0.23f;
            }
        }
    }
}