using RoomReservationSystem.Models;
using RoomReservationSystem.Utilities;

namespace RoomReservationSystem.Services
{
    public static class RoomSearchService
    {
        public static List<Room> SearchAvailableRooms(DateTime start, DateTime end)
        {
            var allRooms = new List<Room>
            {
                new Room { Id = 1, Type = 1, Status = 0, PetsAllowed = true },
                new Room { Id = 2, Type = 2, Status = 0, PetsAllowed = true },
                new Room { Id = 3, Type = 3, Status = 0, PetsAllowed = false },
            };

            // mockdata to test, later check the reservation from DB

            Console.WriteLine($"\n Searching rooms from {start:yyyy-MM-dd} to {end:yyyy-MM-dd} \n");

            return allRooms;
        }

        public static void SearchRooms()
        {
            var (start, end) = DateInputReader.ReadDateRange();
            var availableRooms = SearchAvailableRooms(start, end);

            if (availableRooms.Count == 0)
            {
                Console.WriteLine("No rooms available for the selected dates.\n");
            }
            else
            {
                Console.WriteLine("Available rooms:");
                foreach (var room in availableRooms)
                {
                    Console.WriteLine($" - Room ID: {room.Id}, Type: {room.Type}, Pets Allowed: {room.PetsAllowed}, Status: {room.Status}");
                }
                Console.WriteLine();
            }
        }
    }

    
}
