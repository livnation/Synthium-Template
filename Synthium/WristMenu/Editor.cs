using UnityEngine;

namespace Synthium.WristMenu
{
    internal class Settings
    {
        static int themeRoller;
        static int amountOfThemes = 5; // change to your liking

        static Color32 buttonColorDisabled = new Color32(28, 29, 33, 255); // dark grey
        static Color32 buttonTextColorEnabled = new Color32(60, 195, 80, 255); // light green

        static Color32 menuBackGroundColor = new Color32(12, 52, 94, 255); // navy blue



        private static void ThemeSwitch()
        {
            if (themeRoller < amountOfThemes)
            {
                themeRoller++;
            }
            else
            {
                themeRoller = 0;
            }
            if (themeRoller == 0) // default theme
            {
                buttonColorDisabled = new Color32(28, 29, 33, 255); // dark grey
                buttonTextColorEnabled = new Color32(60, 195, 80, 255); // light green
                menuBackGroundColor = new Color32(12, 52, 94, 255); // navy blue
            }
            if (themeRoller == 1)
            {
                // il do later the actual themes and colors and stuff
            }
            if (themeRoller == 2)
            {
                // il do later the actual themes and colors and stuff
            }
            if (themeRoller == 3) 
            {
                // il do later the actual themes and colors and stuff
            }
            if (themeRoller == 4)
            {
                // il do later the actual themes and colors and stuff
            }
            if (themeRoller == 5)
            {
                // il do later the actual themes and colors and stuff
            }
        }
    }
}
