namespace Synthium.WristMenu.Mods
{
    public class Menu
    {
        public static void SwitchIndex(int index)
        {
            PhysicalMenu.categoryIndex = index;
            PhysicalMenu.DestroyMenu(true);
        }
    }
}