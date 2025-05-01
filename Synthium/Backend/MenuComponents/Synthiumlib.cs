using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Synthium.Backend.MenuComponents
{
    internal class Synthiumlib
    {
        public static Synthiumlib Instance;
        public Color enabledColor { get; private set; }
        public Color disabledColor { get; private set; }
        public bool smooth { get; private set; }
        public Action shootAction { get; private set; }
        public GameObject sphere { get; private set; }

        private GameObject lineBase;

        public static SynthiumData data;
        public Synthiumlib(Color enabled, Color disabled, bool smooth, Action shoot, GameObject sphere)
        {
            if (Instance != null)
            {
                return;
            }
            this.enabledColor = enabled;
            this.disabledColor = disabled;
            this.smooth = smooth;
            this.shootAction = shoot;
            this.sphere = sphere;
            lineBase = new GameObject("Zenbase");
            Instance = this;
        }

        public void UpdateLib()
        {
            if (!ControllerInputPoller.instance.rightGrab) return;

            var hand = GorillaTagger.Instance.rightHandTransform;
            if (Physics.Raycast(hand.position, hand.forward + hand.up * 0.2f, out RaycastHit hit))
            {
                var lineRenderer = lineBase.GetComponent<LineRenderer>() ?? lineBase.AddComponent<LineRenderer>();
                lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                sphere.GetComponent<MeshRenderer>().material.shader = Shader.Find("GUI/Text Shader");
                lineRenderer.material.color = disabledColor;
                lineRenderer.SetPositions(new Vector3[] { hand.position, hit.point });

                var info = hit.collider;
                data = new SynthiumData(
                    info.GetComponentInParent<VRRig>(),
                    info.GetComponentInParent<NetPlayer>(),
                    info.GetComponentInParent<Photon.Realtime.Player>()
                );

                if (ControllerInputPoller.instance.rightControllerIndexFloat == 1f)
                {
                    shootAction?.Invoke();
                }
            }
        }
    }

    internal class SynthiumData
    {
        VRRig Rig;
        NetPlayer NetworkedPlayer;
        Photon.Realtime.Player Player;
        public SynthiumData(VRRig rig, NetPlayer networkedPlayer, Photon.Realtime.Player player)
        {
            this.Rig = rig;
            this.NetworkedPlayer = networkedPlayer;
            this.Player = player;
        }
    }
}
