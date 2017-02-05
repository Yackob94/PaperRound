using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperRound.Core.Models
{
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
