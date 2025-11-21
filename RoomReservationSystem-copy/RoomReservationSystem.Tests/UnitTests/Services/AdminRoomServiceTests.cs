using System;
using System.IO;
using Xunit;
using RoomReservationSystem.Services;

namespace RoomReservationSystem.Tests.UnitTests.Services
{
    public class AdminRoomServiceTests
    {
        [Fact]
        public void ModifyRoom_SelectsRoomAndChangesType_PrintsConfirmation()
        {
            // Arrange
            // Inputs:
            // 1 -> choose room id 1
            // 1 -> choose "Room type" modification
            // 2 -> choose "Double" as new type
            // 4 -> exit modification menu
            var simulatedInput = new StringReader("1\n1\n2\n4\n");
            var originalIn = Console.In;
            var originalOut = Console.Out;
            var outputWriter = new StringWriter();

            try
            {
                Console.SetIn(simulatedInput);
                Console.SetOut(outputWriter);

                // Act
                AdminRoomService.ModifyRoom();

                // Assert
                var output = outputWriter.ToString();
                Assert.Contains("Room 1 type changed to Double", output);
            }
            finally
            {
                // Restore console streams
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}