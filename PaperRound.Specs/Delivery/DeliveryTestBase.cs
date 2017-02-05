using PaperRound.Core;
using PaperRound.Core.Models;

namespace PaperRound.Specs.Delivery
{
    public abstract class DeliveryTestBase<T> where T : IDeliveryMethod, new()
    {
        internal IDeliveryMethod DeliveryMethod;
        internal DeliveryTestBase()
        {
            var parser = new StreetSpecificationParser();
            var factory = new DeliveryFactory();
            var fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\street1.txt");

            DeliveryMethod = factory.CreateDeliveryMethod<T>(fileResult.StreetSpecification);
        }
    }
}
