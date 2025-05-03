using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorillaLocomotion;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using Plane = UnityEngine.Plane;

namespace Synthium.Backend.MenuComponents
{
    internal class GunLib
    {
        public static bool shouldLock = true;
        public static GunLibInfo info;
        private static GameObject Sphere = null;

        public static void Gun(Action action)
        {
            if (ControllerInputPoller.instance.rightGrab && Physics.Raycast(
                    GorillaTagger.Instance.rightHandTransform.position,
                    GorillaTagger.Instance.rightHandTransform.forward, out var hit))
            {
                if (!Sphere)
                {
                    foreach (var comp in new Component[]
                             {
                                 Sphere.GetComponent<BoxCollider>(),
                                 Sphere.GetComponent<Rigidbody>(),
                                 Sphere.GetComponent<Collider>()
                             })
                    {
                        if (comp != null) GameObject.Destroy(comp);
                    }
                }
            }
        }


        internal class GunLibInfo
        {
            public VRRig Rig;
            public NetPlayer NetworkedPlayer;
            public Photon.Realtime.Player Player;

            public GunLibInfo(VRRig rig, NetPlayer networkedPlayer, Photon.Realtime.Player player)
            {
                this.Rig = rig;
                this.NetworkedPlayer = networkedPlayer;
                this.Player = player;
            }
        }
    }
}