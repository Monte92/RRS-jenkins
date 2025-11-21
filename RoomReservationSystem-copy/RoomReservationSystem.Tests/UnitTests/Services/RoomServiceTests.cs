using Microsoft.Data.Sqlite;
using RoomReservationSystem.Services;

namespace RoomReservationSystem.Tests.UnitTests.Services
{
    public class RoomServiceTests
    {
        [Fact]
        public void GetAllRoomsReturnsAllRooms()
        {
            using (var connection = new SqliteConnection("DataSource=:memory:"))
            {
                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText =
                    """
                    CREATE TABLE IF NOT EXISTS "room" (
                    	"room_id"	INTEGER,
                    	"room_type"	INTEGER,
                    	"status"	INTEGER NOT NULL DEFAULT 0,
                    	"pets_allowed"	INTEGER NOT NULL DEFAULT 0,
                    	PRIMARY KEY("room_id" AUTOINCREMENT)
                    );
                    INSERT INTO "room" VALUES (1,1,0,0);
                    INSERT INTO "room" VALUES (2,2,0,0);
                    """;

                command.ExecuteNonQuery();

                var result = RoomService.GetAllRooms(connection);

                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.Collection(result,
                    room =>
                    {
                        Assert.Equal(1, room.Id);
                        Assert.Equal(1, room.Type);
                        Assert.Equal(0, room.Status);
                        Assert.False(room.PetsAllowed);
                    },
                    room =>
                    {
                        Assert.Equal(2, room.Id);
                        Assert.Equal(2, room.Type);
                        Assert.Equal(0, room.Status);
                        Assert.False(room.PetsAllowed);
                    });
            }
        }
    }
}
