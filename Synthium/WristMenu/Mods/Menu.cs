namespace Synthium.WristMenu.Mods
{
    public class Menu
    {
        public static void SwitchIndex(int index)
        {
            PhysicalMenu.categoryIndex = index;
            PhysicalMenu.DestroyMenu(true);
        }

        public static void ToggleFingers()
        {
            Backend.Patches.FingerPatch1.fingersEnabled = !Backend.Patches.FingerPatch1.fingersEnabled;
        }
    }
}