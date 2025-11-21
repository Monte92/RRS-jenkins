namespace RoomReservationSystem.Utilities
{
    public class MenuPrinter
    {
        public static void PrintMenu(List<string> menuItems, bool addNumbering = false)
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                var prefix = addNumbering ? $"{i + 1}. " : "";
                Console.WriteLine($"{prefix}{menuItems[i]}");
            }
            Console.WriteLine();
        }
    }
}
