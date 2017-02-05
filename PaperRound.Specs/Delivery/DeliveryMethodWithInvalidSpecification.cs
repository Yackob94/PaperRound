using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperRound.Core;
using Xunit;

namespace PaperRound.Specs.Delivery
{
    [Trait("User selects delivery method with an invalid specification", "")]
    public class DeliveryMethodWithInvalidSpecification
    {
        [Fact(DisplayName = "No delivery method is created")]
        private void NullDelivery()
        {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "User knows why delivery method is not created")]
        private void ReasonMessage()
        {
            throw new NotImplementedException();
        }
    }
}
