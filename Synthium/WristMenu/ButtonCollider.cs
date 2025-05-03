using System.Collections.Generic;
using UnityEngine;

namespace Synthium.WristMenu
{
    public class ButtonCollider : MonoBehaviour
    {
        public string text;
        public static float delay;

        public void OnTriggerEnter(Collider collider)
        {
            if (collider == PhysicalMenu.clickerCollider && Time.time >= delay)
            {
                delay = Time.time + 0.3f;
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(138, true, 0.25f);
                PhysicalMenu.ToggleButton(text);
            }
        }
    }

}