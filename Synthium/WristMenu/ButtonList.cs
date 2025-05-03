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
                new Button { buttonText = "Room", toggle = false, method = () => { Menu.SwitchIndex(1); }},
                new Button { buttonText = "Settings", toggle = true, enableMethod = () => { Menu.SwitchIndex(2); }},
                new Button { buttonText = "Player", toggle = true, enableMethod = () => { Menu.SwitchIndex(3); }},
                new Button { buttonText = "Air Jump", toggle = true, enableMethod = () => { Movement.AirJump(); }},
                new Button { buttonText = "Gun Lib", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "Flu", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dfd", toggle = true, enableMethod = () => { Player.GunLib(); }},
            },
            new Button[]
            {
                new Button { buttonText = "Return To Home", toggle = false, method = () => { Menu.SwitchIndex(0); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
            },
            new Button[]
            {
                new Button { buttonText = "Return To Home", toggle = false, method = () => { Menu.SwitchIndex(0); }},
                new Button { buttonText = "fas", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "saf", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsaasfasd", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "safsf", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsaassad", toggle = true, enableMethod = () => { Player.GunLib(); }},
            },
            new Button[]
            {
                new Button { buttonText = "Return To Home", toggle = false, method = () => { Menu.SwitchIndex(0); }},
                new Button { buttonText = "dont make me pull the toys out", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
                new Button { buttonText = "dsad", toggle = true, enableMethod = () => { Player.GunLib(); }},
            },
        };
    }
}
