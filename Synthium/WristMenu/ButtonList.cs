using Synthium.WristMenu.Mods;
using Photon.Pun;
using Synthium.Backend.MenuComponents;

namespace Synthium.WristMenu
{
    internal class ButtonList
    {
        public static Button[][] Buttons = new Button[][]
        {
            new Button[]
            {
                new Button { buttonText = "Disconnect", toggle = false, method = () => { PhotonNetwork.Disconnect(); }},
                new Button { buttonText = "Disable Fingers", toggle = false, method = () => { Menu.ToggleFingers(); }},
                new Button { buttonText = "Air Jump", toggle = true, enableMethod = () => { Movement.AirJump(); }},
                new Button { buttonText = "Fly", toggle = true, enableMethod = () => { Movement.Fly(); }},
                new Button { buttonText = "Chams", toggle = true, enableMethod = () => { Player.Chams(); }, disable = () => { Player.DisableChams(); }},
                new Button { buttonText = "Placeholder1", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder2", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder3", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder4", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder5", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder6", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder7", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder8", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Placeholder9", toggle = true, enableMethod = () => { Player.GunLib(); }},
            },
        };
    }
}
