using RoomReservationSystem.Utilities;
using System;
using Xunit;

namespace RoomReservationSystem.Tests.UnitTests.Utilities
{
    public class DateInputReaderTests
    {
        [Theory]
        [InlineData("2025-11-05", "2025-11-06", true)]
        [InlineData("2025-11-06", "2025-11-05", false)]
        [InlineData("2025-11-05", "2025-11-05", false)]
        [InlineData("2025-11-05", "2025-11-30", true)]
        public void TryValidateDateRange_ReturnsExpectedResult(string startStr, string endStr, bool expected)
        {

            DateTime start = DateTime.Parse(startStr);
            DateTime end = DateTime.Parse(endStr);

            bool isValid = DateInputReader.TryValidateDateRange(start, end);

            Assert.Equal(expected, isValid);
        }
    }
}
