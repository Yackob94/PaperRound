using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("Specification file is empty", "")]

    public class FileIsEmpty
    {
        private readonly FileResult _fileResult;
        public FileIsEmpty()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\Empty.txt");
        }

        [Fact(DisplayName = "User receives message that the file is not valid")]
        private void FileIsNotValid()
        {
            Assert.False(_fileResult.Valid);
        }

        [Fact(DisplayName = "User knows why the file is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotBeEmpty, _fileResult.Message);
        }
    }
}
