using System.Collections.Generic;
using System.Linq;
using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Delivery
{
    [Trait("User selects clockwise delivery method", "")]
    public class ValidClockwiseDeliveryMethod
    {
        private ClockwiseDeliveryMethod _method;
        public ValidClockwiseDeliveryMethod()
        {
            var parser = new StreetSpecificationParser();
            var fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\street1.txt");
            _method = new ClockwiseDeliveryMethod(fileResult.StreetSpecification);
        }

        [Fact(DisplayName = "Display list of houses in order of delivery")]
        private void ListOfHouses()
        {
            var expectedDeliveryRoute = new List<int>(new[] { 1, 3, 5, 7, 9, 11, 13, 15, 12, 10, 8, 6, 4, 2 });
            Assert.Equal(expectedDeliveryRoute, _method.DeliveryRoute);
        }
        [Fact(DisplayName = "Display the number of times the paper person will have to cross the road")]
        private void NumberOfTimesToCrossTheRoad()
        {
            Assert.Equal(1, _method.CrossingRoadCount);
        }
    }

    public class ClockwiseDeliveryMethod
    {
        // House numbers in order to be delivered
        public ICollection<int> DeliveryRoute { get; set; }
        // Number of times the road needs to be crossed to deliver the papers
        public int CrossingRoadCount { get; set; }

        public ClockwiseDeliveryMethod(StreetSpecification specification)
        {
            CrossingRoadCount = 1;

            var deliveryRoute = specification.LeftHouses.ToList();
            deliveryRoute.AddRange(specification.RightHouses.OrderByDescending(h => h));

            DeliveryRoute = deliveryRoute;
        }
    }
}
