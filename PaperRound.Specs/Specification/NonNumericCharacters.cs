using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("Specification file contains non-numeric characters", "")]

    public class NonNumericCharacters
    {
        private readonly FileResult _fileResult;
        public NonNumericCharacters()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\NonNumericCharacters.txt");
        }

        [Fact(DisplayName = "A message that the file is not valid")]
        private void FileIsNotValid()
        {
            Assert.False(_fileResult.Valid);
        }

        [Fact(DisplayName = "User knows why the file is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotHaveNonNumerics, _fileResult.Message);
        }
    }
}
