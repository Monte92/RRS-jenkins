using Xunit;
using RoomReservationSystem.Utilities;

namespace RoomReservationSystem.Tests.UnitTests.Utilities;

    public class CalculatorTests
{
    [Fact]
    public void CalculateDifference_ShouldReturnCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 4;
        int expected = 6;

        // Act
        int result = BasicOperations.CalculateDifference(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateDifference_WithNegativeResult_ShouldReturnCorrectDifference()
    {
        // Arrange
        int a = 3;
        int b = 7;
        int expected = -4;

        // Act
        int result = BasicOperations.CalculateDifference(a, b);

        // Assert
        Assert.Equal(expected, result);
    }
}
