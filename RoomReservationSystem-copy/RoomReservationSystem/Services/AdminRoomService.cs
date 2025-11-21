using RoomReservationSystem.Utilities;
using RoomReservationSystem.Models;

namespace RoomReservationSystem.Services
{
    public static class AdminRoomService
    {
       public static void ModifyRoom()
        {
            var rooms = RoomSearchService.SearchAvailableRooms(DateTime.MinValue, DateTime.MaxValue);

            Console.WriteLine("Choose room id to modify:");

            var input = InputReader.ReadInt(1, 4);
            var selectedRoom = rooms[input - 1];

            Console.WriteLine($"Modifying Room {input}...\n");
            
            while (true)
            {
                Console.WriteLine("Choose a modification:");
                var modifyMenuOptions = new List<string>
                 {
                  "Room type",
                  "Pets allowed",
                  "Status",
                  "Exit modification menu"
                 };
                MenuPrinter.PrintMenu(modifyMenuOptions, true);
                var modifyInput = InputReader.ReadInt(1, modifyMenuOptions.Count);

                if (modifyInput == 4)
                {
                    break;
                }

                switch (modifyInput)
                {
                    case 1:
                        Console.WriteLine("Modifying room type...\n");
                        Console.WriteLine("Select new room type:");
                        var roomTypes = new List<string>
                             {
                              "Single",
                              "Double",
                              "Suite",
                             };
                        var roomTypeInput = InputReader.ReadInt(1, roomTypes.Count);
                        selectedRoom.Type = roomTypeInput;
                        Console.WriteLine($"Room {selectedRoom.Id} type changed to {roomTypes[roomTypeInput - 1]}.\n");
                        break;

                    case 2:
                        Console.WriteLine("Modifying pet policy...\n");
                        Console.WriteLine("Select new policy:");
                        var petPolicies = new List<string>
                             {
                              "Allowed",
                              "Not Allowed"
                             };
                        var petTypeInput = InputReader.ReadInt(1, petPolicies.Count);
                        if (petTypeInput == 1)
                        {
                            selectedRoom.PetsAllowed = true;
                        }
                        else
                        {
                            selectedRoom.PetsAllowed = false;
                        }

                        Console.WriteLine($"Room {selectedRoom.Id} pet policy changed to {petPolicies[petTypeInput - 1]}.\n");
                        break;

                    case 3:
                        Console.WriteLine("Modifying status...\n");
                        Console.WriteLine("Set new status:");
                        var roomStatus = new List<string>
                             {
                              "Vacant",
                              "Occupied"
                             };
                        var statusTypeInput = InputReader.ReadInt(1, roomStatus.Count);
                        if (statusTypeInput == 1)
                        {
                            selectedRoom.Status = 1;
                        }
                        else
                        {
                            selectedRoom.Status = 2;
                        }

                        Console.WriteLine($"Room {selectedRoom.Id} status changed to {roomStatus[statusTypeInput - 1]}.\n");
                        break;
                    default:
                        break;
                }
            }
        }
        public static void AddRoom()
        {

        }
        public static void DeleteRoom()
        {

        }
    }


}
