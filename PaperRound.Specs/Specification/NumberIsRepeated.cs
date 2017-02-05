using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("Specification file has a duplicate house", "")]

    public class NumberIsRepeated
    {
        private readonly FileResult _fileResult;
        public NumberIsRepeated()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\NumberIsRepeated.txt");
        }

        [Fact(DisplayName = "User receives message that the specification is not valid")]
        private void SpecificationIsNotValid()
        {
            Assert.False(_fileResult.StreetSpecification.Valid);
        }

        [Fact(DisplayName = "User knows why the specification is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotBeRepeated, _fileResult.StreetSpecification.Message);
        }
    }
}
