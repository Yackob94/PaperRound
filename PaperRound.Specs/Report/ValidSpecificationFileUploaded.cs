using System;
using System.IO;
using System.Linq;
using Xunit;

namespace PaperRound.Specs.Report
{
    [Trait("A valid specification file is uploaded", "")]
    public class ValidSpecificationFileUploaded
    {
        private readonly FileResult _fileResult;

        public ValidSpecificationFileUploaded()
        {
            var parser = new StreetSpecificationParser();
            _fileResult = parser.ParseStreetSpecification("..\\..\\Specifications\\ValidSpecificationFile.txt");
        }
        [Fact(DisplayName = "A message that the file is valid")]
        void FileIsValid()
        {
            Assert.True(_fileResult.Valid);
        }

        [Fact(DisplayName = "Number of houses on a street")]
        void NumberOfHouses()
        {
            Assert.Equal(_fileResult.StreetSpecification.RightHouses + _fileResult.StreetSpecification.LeftHouses, _fileResult.StreetSpecification.TotalHouses);
        }

        [Fact(DisplayName = "Number of houses on the left of the street")]
        void NumberOfHousesOnTheLeft()
        {
            Assert.Equal(_fileResult.StreetSpecification.RightHouses, 6);
        }

        [Fact(DisplayName = "Number of houses on the right of the street")]
        void NumberOfHousesOnTheRight()
        {
            Assert.Equal(_fileResult.StreetSpecification.LeftHouses, 5);
        }
    }

    public class FileResult
    {
        public bool Valid { get; set; }
        public StreetSpecification StreetSpecification { get; set; }
    }

    public class StreetSpecification
    {
        public int LeftHouses { get; }
        public int RightHouses { get; }
        public int TotalHouses => LeftHouses + RightHouses;

        public StreetSpecification(int leftHouses, int rightHouses)
        {
            LeftHouses = leftHouses;
            RightHouses = rightHouses;
        }
    }

    public class StreetSpecificationParser
    {

        public FileResult ParseStreetSpecification(string relaitveFilePath)
        {
            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), relaitveFilePath));

            if (!File.Exists(filePath))
                throw new ArgumentException($"File does not exist at path {filePath}");

            string specification;
            using (var reader = new StreamReader(filePath))
            {
                specification = reader.ReadLine();
            }

            var specArry = specification.Split(' ');

            var houseNumbers = specArry.Select(int.Parse).ToArray();

            var oddNumbers = houseNumbers.Where(n => n % 2 != 0);
            var evenNumbers = houseNumbers.Where(n => n % 2 == 0);

            return new FileResult
            {
                StreetSpecification = new StreetSpecification(oddNumbers.Count(), evenNumbers.Count()),
                Valid = true
            };
        }
    }
}

