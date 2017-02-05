using PaperRound.Core.Models;
using System.Collections.Generic;
using Xunit;

namespace PaperRound.Specs.Delivery
{
    [Trait("User selects alternate delivery method", "")]
    public class ValidAlternateDeliveryMethod : DeliveryTestBase<AlternateDeliveryMethod>
    {
        [Fact(DisplayName = "Display list of houses in order of delivery")]
        private void ListOfHouses()
        {
            var expectedDeliveryRoute = new List<int>(new[] { 1, 2, 4, 3, 6, 5, 7, 8, 9, 10, 12, 11, 13, 15 });
            Assert.Equal(expectedDeliveryRoute, DeliveryMethod.DeliveryRoute);
        }
        [Fact(DisplayName = "Display the number of times the paper person will have to cross the road")]
        private void NumberOfTimesToCrossTheRoad()
        {
            Assert.Equal(8, DeliveryMethod.CrossingRoadCount);
        }
    }
}
