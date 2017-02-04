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
            _fileResult = parser.ParseStreetSpecification("..\\..\\Specifications\\NumberIsRepeated.txt");
        }

        [Fact(DisplayName = "A message that the file is not valid")]
        private void FileIsNotValid()
        {
            Assert.False(_fileResult.Valid);
        }

        [Fact(DisplayName = "User knows why the file is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotBeRepeated, _fileResult.Message);
        }
    }
}
