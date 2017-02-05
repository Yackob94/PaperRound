using System.Collections.Generic;
using System.Linq;

namespace PaperRound.Core.Models
{
    public class ClockwiseDeliveryMethod : IDeliveryMethod
    {
        // House numbers in order to be delivered
        public List<int> DeliveryRoute { get; set; }
        // Number of times the road needs to be crossed to deliver the papers
        public int CrossingRoadCount { get; set; }

        public void GenerateDelivery(StreetSpecification specification)
        {
            CrossingRoadCount = 1;

            var deliveryRoute = specification.LeftHouses.ToList();
            deliveryRoute.AddRange(specification.RightHouses.OrderByDescending(h => h));

            DeliveryRoute = deliveryRoute;
        }
    }
}
