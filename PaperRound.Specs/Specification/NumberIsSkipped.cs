using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("Specification file skips a number in the sequence", "")]

    public class NumberIsSkipped
    {
        private readonly FileResult _fileResult;
        public NumberIsSkipped()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\NumberIsSkipped.txt");
        }

        [Fact(DisplayName = "User receives message that the specification is not valid")]
        private void SpecificationIsNotValid()
        {
            Assert.False(_fileResult.StreetSpecification.Valid);
        }

        [Fact(DisplayName = "User knows why the specification is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotBeSkipped, _fileResult.StreetSpecification.Message);
        }
    }
}
