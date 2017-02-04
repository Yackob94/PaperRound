using PaperRound.Core;
using PaperRound.Core.Models;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("A valid specification file is uploaded", "")]
    public class ValidSpecificationFileUploaded
    {
        private readonly FileResult _fileResult;

        public ValidSpecificationFileUploaded()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\SpecificationExamples\\ValidSpecificationFile.txt");
        }
        [Fact(DisplayName = "A message that the file is valid")]
        private void FileIsValid()
        {
            Assert.True(_fileResult.Valid);
        }

        [Fact(DisplayName = "Number of houses on a street")]
        private void NumberOfHouses()
        {
            Assert.Equal(_fileResult.StreetSpecification.RightHouses + _fileResult.StreetSpecification.LeftHouses, _fileResult.StreetSpecification.TotalHouses);
        }

        [Fact(DisplayName = "Number of houses on the left of the street")]
        private void NumberOfHousesOnTheLeft()
        {
            Assert.Equal(_fileResult.StreetSpecification.RightHouses, 6);
        }

        [Fact(DisplayName = "Number of houses on the right of the street")]
        private void NumberOfHousesOnTheRight()
        {
            Assert.Equal(_fileResult.StreetSpecification.LeftHouses, 5);
        }
    }
}

