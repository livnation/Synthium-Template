using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.Pun;
using Synthium.Backend.ConsoleLibrary;
using Synthium.Backend.MenuComponents;

namespace Synthium.WristMenu
{
    internal class ButtonList
    {
        public static Button[][] Buttons = new Button[][]
        {
            new Button[]
            {
                new Button { buttonText = "Brrooo mod menu", toggle = false, method = () => { PhysicalMenu.categoryIndex = 1; }},
                new Button { buttonText = "Disconnect", toggle = false, method = () => { PhotonNetwork.Disconnect(); }},
                new Button { buttonText = "Fly", toggle = true, enableMethod = () => { Exploits.Movement.Fly(); }},
                new Button { buttonText = "towdawd"},
                new Button { buttonText = "togglable placeholder 6"},
                new Button { buttonText = "togglable placeholder 6"},
            },
            new Button[]
            {
                new Button { buttonText = "category  6"},
                new Button { buttonText = "togglable placeholder 6"},
                new Button { buttonText = "togglable placeholder 6"},
                new Button { buttonText = "togglable placeholder 6"},
                new Button { buttonText = "togglable placeholder 6"},
            },
        };
    }
}
