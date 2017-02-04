using System;
using Xunit;

namespace PaperRound.Specs.Report
{
    [Trait("A valid specification file is uploaded", "")]
    public class ValidSpecificationFileUploaded
    {
        [Fact(DisplayName = "A message that the file is valid")]
        void FileIsValid()
        {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "Number of houses on a street")]
        void NumberOfHouses()
        {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "Number of houses on the left of the street")]
        void NumberOfHousesOnTheLeft()
        {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "Number of houses on the right of the street")]
        void NumberOfHousesOnTheRight()
        {
            throw new NotImplementedException();
        }
    }
}
