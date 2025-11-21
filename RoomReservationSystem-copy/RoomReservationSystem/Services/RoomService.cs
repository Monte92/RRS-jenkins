using Microsoft.Data.Sqlite;
using RoomReservationSystem.Models;

namespace RoomReservationSystem.Services
{
    public class RoomService
    {
        public static List<Room> GetAllRooms(SqliteConnection connection)
        {
            List<Room> rooms = [];

            // TODO: Needs try catching etc.

            using (connection)
            {
                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = """
                SELECT * FROM room;

                """;

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rooms.Add(
                        new Room
                        {
                            Id = reader.GetInt32(0),
                            Type = reader.GetInt32(1),
                            Status = reader.GetInt32(2),
                            PetsAllowed = reader.GetBoolean(3)
                        });
                }
            }

            return rooms;
        }

    }
}
