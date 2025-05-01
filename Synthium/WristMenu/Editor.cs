using UnityEngine;

namespace Synthium.WristMenu
{
    internal class Settings
    {
        public static int themeRoller;
        static int amountOfThemes = 5; // change to your liking

        static Color32 buttonColorDisabled = new Color32(28, 29, 33, 255); // dark grey
        static Color32 buttonTextColorEnabled = new Color32(60, 195, 80, 255); // light green

        public static Color32 menuBackGroundColor = new Color32(12, 52, 94, 255); // navy blue

        static void ChangeTheme(Color32 btnDisabled, Color32 btnEnabled, Color32 background)
        {
            buttonColorDisabled = btnDisabled;
            buttonTextColorEnabled = btnEnabled;
            menuBackGroundColor = background;
        }

        public static void ThemeSwitch()
        {
            /*
                shortened themeroller increment method, changed to switch statement
                also made ThemeSwitch public, and added a changetheme function so its easier ig
            */
            themeRoller = (themeRoller + 1) % amountOfThemes;
            switch (themeRoller)
            {
                case 0:
                    // main theme, grey navy wtv
                    ChangeTheme(
                        new Color32(28, 29, 33, 255),
                        new Color32(60, 195, 80, 255),
                        new Color32(12, 52, 94, 255)
                    );
                    break;
                case 1:
                    // purple theme
                    ChangeTheme(
                        new Color32(47, 0, 204, 1),
                        new Color32(30, 0, 133, 1),
                         new Color32(129, 0, 238,1)
                    );
                    break;
                case 2:
                    // blue black gradient
                    Backend.MenuComponents.Gradient.AddGradientComponent(PhysicalMenu.menu, Color.blue, Color.black);
                    break;
                case 3:
                    // nice bubblegum gradient
                    Color start = PhysicalMenu.GetHex("#FF9AE3");
                    Color end = PhysicalMenu.GetHex("#A1C4FD");
                    Synthium.Backend.MenuComponents.Gradient.AddGradientComponent(PhysicalMenu.menu, start, end, 0.5f);
                    break;
                // add rest
                case 4:
                    break;
                case 5:
                    break;
            }
        }
    }
}
