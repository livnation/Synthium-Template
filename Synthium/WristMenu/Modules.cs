using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthium.Backend.WristMenu
{
    public class Module
    {
        public string buttonText = string.Empty;
        public Action method;
        public Action onDisable;
        public bool enabledOnStartup = false;
        public bool toggle = true;
    }

    public class Buttons
    {
        private static void PlaceHolder()
        {

        }
        public static Module[] ButtonList = new Module[]
        {
            new Module
            {
                buttonText = "YourMod", // enter the title of the module
                method = () => PlaceHolder(), // IMPLEMENT YOUR METHOD
                onDisable = () => PlaceHolder(), // this will be what is referenced when your module gets disabled
                enabledOnStartup = true, // this will be if your module will be enabled when you start up your game
                toggle = true, // this will show if your module will be toggleable, or a click and it executes it once, if it is set to true, the method will be being executed the whole time this is enabled, and basically if its false it gets enabled for not even a second then turns off so use false for disconnect and stuff
            }
        };
    }
}
