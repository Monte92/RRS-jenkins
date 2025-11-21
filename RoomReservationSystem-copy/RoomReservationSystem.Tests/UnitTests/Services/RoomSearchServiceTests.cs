using RoomReservationSystem.Models;
using RoomReservationSystem.Services;
using System;
using System.Linq;
using Xunit;
//test
namespace RoomReservationSystem.Tests.UnitTests.Services
{
    public class RoomSearchServiceTests
    {
        [Fact]
        public void SearchAvailableRooms_ReturnsRooms()
        {
           
            DateTime start = new(2025, 11, 6);
            DateTime end = new(2025, 11, 8);
            
            var rooms = RoomSearchService.SearchAvailableRooms(start, end);

            Assert.NotNull(rooms);
            Assert.True(rooms.Count > 0);
            Assert.All(rooms, r => Assert.IsType<Room>(r));
        }
    }
}
