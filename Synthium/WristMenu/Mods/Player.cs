using UnityEngine;
using Synthium.Backend.MenuComponents;

namespace Synthium.WristMenu.Mods
{
    public class Player
    {
        public static GameObject sphere;
        public static void GunLib()
        {
            // Coming in V2
        }
        public static void Chams()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig.isOfflineVRRig) continue;
        
                rig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                rig.mainSkin.material.color = rig.mainSkin.material.name.Contains("infected") ? Color.red : Color.green;
            }
        }

        public static void DisableChams()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
        
                rig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
            }
        }
    }
}