using System;
using PaperRound.Core.Models;

namespace PaperRound.Core
{
    public class DeliveryFactory
    {
        public T CreateDeliveryMethod<T>(StreetSpecification specification) where T : IDeliveryMethod, new()
        {
            if (specification == null)
                throw new ArgumentException($"{nameof(specification)} cannot be null");

            var delivery = new T();

            delivery.GenerateDelivery(specification);

            return delivery;
        }
    }
}
