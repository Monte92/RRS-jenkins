using Xunit;
using RoomReservationSystem.Utilities;

namespace RoomReservationSystem.Tests.Utilities
{
    public class SumTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(-1, 1, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(int.MaxValue, 0, int.MaxValue)]
        [InlineData(int.MinValue, 0, int.MinValue)]
        public void CalculateSum_ReturnsExpected(int a, int b, int expected)
        {
            var result = Sum.CalculateSum(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public void CalculateSum_OverflowBehavior_MatchesUncheckedAddition(int a, int b)
        {
            var expected = unchecked(a + b);
            var result = Sum.CalculateSum(a, b);
            Assert.Equal(expected, result);
        }
    }
}   