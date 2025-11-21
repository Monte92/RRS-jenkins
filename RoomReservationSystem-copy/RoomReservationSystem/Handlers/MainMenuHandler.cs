using RoomReservationSystem.Models;
using RoomReservationSystem.Utilities;
using RoomReservationSystem.Services;

namespace RoomReservationSystem.Handlers
{
    public class MainMenuHandler
    {
        private static readonly string mainMenuPrompt = "Select option: ";

        private static readonly List<string> mainMenuOptions =
        [
            "Guest",
            "Receptionist",
            "Admin"
        ];

        public static void PrintMainMenu()
        {
            MenuPrinter.PrintMenu(mainMenuOptions, true);
        }

        public static void HandleNavigation()
        {
            while (true)
            {
                PrintMainMenu();
                var input = InputReader.ReadInt(1, mainMenuOptions.Count, mainMenuPrompt);

                switch (input)
                {
                    case 1:
                        // Just for example, replace with actual functionality
                        /*var rooms = RoomService.GetAllRooms(new DatabaseService().GetConnection());
                        Console.WriteLine(String.Join(", ", rooms));*/
                        RoomSearchService.SearchRooms();
                        break;

                    case 2:
                        break;

                    case 3:
                        RoomSearchService.SearchRooms();
                        var adminMenuOptions = new List<string>
                            {
                                "Modify room",
                                "Add room",
                                "Delete room"
                            };
                        Console.WriteLine("Choose an action");
                        MenuPrinter.PrintMenu(adminMenuOptions, true);
                        var adminInput = InputReader.ReadInt(1, adminMenuOptions.Count);
                        switch (adminInput)
                        {
                            case 1:
                                Console.WriteLine("Modify room selected");
                                AdminRoomService.ModifyRoom();
                                break;
                            case 2:
                                Console.WriteLine("Add room selected");
                                break;
                            case 3:
                                Console.WriteLine("Delete room selected");
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
