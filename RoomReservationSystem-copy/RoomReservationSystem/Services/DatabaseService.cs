using Microsoft.Data.Sqlite;

namespace RoomReservationSystem.Services
{
    public class DatabaseService
    {
        public SqliteConnection GetConnection()
        {
            using var connection = new SqliteConnection("Data Source=Data/room_reservation_system.db");

            return connection;
        }
    }
}
