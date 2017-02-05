using System.Collections.Generic;

namespace PaperRound.Core.Models
{
    public class AlternateDeliveryMethod : IDeliveryMethod
    {
        // House numbers in order to be delivered
        public List<int> DeliveryRoute { get; set; }
        // Number of times the road needs to be crossed to deliver the papers
        public int CrossingRoadCount { get; set; }

        public void GenerateDelivery(StreetSpecification specification)
        {
            DeliveryRoute = specification.Houses;
            var previousWasEven = false;
            for (var i = 0; i < specification.Houses.Count; i++)
            {
                if (specification.Houses[i] % 2 == 0)
                {
                    // if we have just started we don't want to count our starting road as crossing over
                    if (!previousWasEven && i != 0)
                        CrossingRoadCount++;

                    previousWasEven = true;
                }
                else
                {
                    // if we have just started we don't want to count our starting road as crossing over
                    if (previousWasEven && i != 0)
                        CrossingRoadCount++;

                    previousWasEven = false;
                }
            }
        }
    }
}
