using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("Specification file has numbers in descending order", "")]

    public class NumbersDescending
    {
        private readonly FileResult _fileResult;
        public NumbersDescending()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\DescendingHouses.txt");
        }

        [Fact(DisplayName = "User receives message that the specification is not valid")]
        private void SpecificationIsNotValid()
        {
            Assert.False(_fileResult.StreetSpecification.Valid);
        }

        [Fact(DisplayName = "User knows why the specification is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotHaveDescendingNumbers, _fileResult.StreetSpecification.Message);
        }
    }
}
