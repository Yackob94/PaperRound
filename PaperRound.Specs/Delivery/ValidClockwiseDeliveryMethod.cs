using System.Collections.Generic;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Delivery
{
    [Trait("User selects clockwise delivery method", "")]
    public class ValidClockwiseDeliveryMethod : DeliveryTestBase<ClockwiseDeliveryMethod>
    {
        [Fact(DisplayName = "Display list of houses in order of delivery")]
        private void ListOfHouses()
        {
            var expectedDeliveryRoute = new List<int>(new[] { 1, 3, 5, 7, 9, 11, 13, 15, 12, 10, 8, 6, 4, 2 });
            Assert.Equal(expectedDeliveryRoute, DeliveryMethod.DeliveryRoute);
        }
        [Fact(DisplayName = "Display the number of times the paper person will have to cross the road")]
        private void NumberOfTimesToCrossTheRoad()
        {
            Assert.Equal(1, DeliveryMethod.CrossingRoadCount);
        }
    }
}
