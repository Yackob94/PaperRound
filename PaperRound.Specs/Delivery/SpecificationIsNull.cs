using System;
using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Delivery
{
    [Trait("A null specification is passed to the Delivery Factory", "")]
    public class SpecificationIsNull
    {
        private readonly DeliveryFactory _deliveryFactory;
        public SpecificationIsNull()
        {
            _deliveryFactory = new DeliveryFactory();
        }
        [Fact(DisplayName = "The Delivery Factory throws an Argument Exception")]
        private void DeliveryFactoryThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _deliveryFactory.CreateDeliveryMethod<ClockwiseDeliveryMethod>(null));
        }
    }
}
