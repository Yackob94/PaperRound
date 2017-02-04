using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("Specification file has multiple lines", "")]

    public class FileMutlipleLines
    {
        private readonly FileResult _fileResult;
        public FileMutlipleLines()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\FileMutlipleLines.txt");
        }

        [Fact(DisplayName = "User receives message that the file is not valid")]
        private void FileIsNotValid()
        {
            Assert.False(_fileResult.Valid);
        }

        [Fact(DisplayName = "User knows why the file is not valid")]
        private void ReasonMessage()
        {
            Assert.Equal(Messages.CannotHaveMultipleLines, _fileResult.Message);
        }
    }
}
