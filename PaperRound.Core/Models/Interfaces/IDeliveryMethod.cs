using System.Collections.Generic;

namespace PaperRound.Core.Models
{
    public interface IDeliveryMethod
    {
        // House numbers in order to be delivered
        List<int> DeliveryRoute { get; set; }
        // Number of times the road needs to be crossed to deliver the papers
        int CrossingRoadCount { get; set; }

        void GenerateDelivery(StreetSpecification specification);
    }
}
