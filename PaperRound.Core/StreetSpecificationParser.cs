using PaperRound.Core.Models;
using System;
using System.IO;
using System.Linq;

namespace PaperRound.Core
{
    public class StreetSpecificationParser
    {
        public FileResult ParseStreetSpecification(string relaitveFilePath)
        {
            // Get file
            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), relaitveFilePath));

            if (!File.Exists(filePath))
                throw new ArgumentException($"File does not exist at path {filePath}");

            var fileResult = ValidateFile(filePath);

            if (!fileResult.Valid)
                return fileResult;

            var oddNumbers = fileResult.HouseNumbers.Where(n => n % 2 != 0).ToArray();
            var evenNumbers = fileResult.HouseNumbers.Where(n => n % 2 == 0).ToArray();

            // Validate the numbers
            fileResult.StreetSpecification = ValidateSpecification(oddNumbers, evenNumbers);

            return fileResult;
        }

        private StreetSpecification ValidateSpecification(int[] oddNumbers, int[] evenNumbers)
        {
            var evenNumberCount = evenNumbers.Length;
            var oddNumberCount = oddNumbers.Length;

            var distinctEvenNumberCount = evenNumbers.Distinct().Count();
            var distinctOddNumberCount = oddNumbers.Distinct().Count();

            // Check to make sure each house only appears once
            if (distinctEvenNumberCount != evenNumberCount || distinctOddNumberCount != oddNumberCount)
            {
                return new StreetSpecification
                {
                    Valid = false,
                    Message = Messages.CannotBeRepeated
                };
            }

            var orderedEvenNumbers = evenNumbers.OrderBy(n => n);
            var orderedOddNumbers = oddNumbers.OrderBy(n => n);

            var expectedEvenCount = orderedEvenNumbers.Last() / 2;
            var expectedOddCount = Math.Ceiling((double)orderedOddNumbers.Last() / 2);

            // If we have higher last number than the actual count
            // then a number has been missed
            if (expectedEvenCount > evenNumberCount || expectedOddCount > oddNumberCount)
            {
                return new StreetSpecification
                {
                    Valid = false,
                    Message = Messages.CannotBeSkipped
                };
            }

            return new StreetSpecification
            {
                Valid = true,
                LeftHouses = oddNumberCount,
                RightHouses = evenNumberCount
            };
        }

        private FileResult ValidateFile(string filePath)
        {
            string specification;

            // Read the first line
            using (var reader = new StreamReader(filePath))
            {
                specification = reader.ReadLine();

                // Check to see if the file has more than one line
                if (reader.ReadLine() != null)
                {
                    return new FileResult
                    {
                        Valid = false,
                        Message = Messages.CannotHaveMultipleLines
                    };
                }
            }

            // If it's empty return a not valid result
            if (string.IsNullOrWhiteSpace(specification))
            {
                return new FileResult
                {
                    Valid = false,
                    Message = Messages.CannotBeEmpty
                };
            }

            var specArry = specification.Split(' ');
            int[] houseNumbers;
            try
            {
                // Parse the numbers
                houseNumbers = specArry.Select(int.Parse).ToArray();
            }
            catch (FormatException)
            {
                // Catch any non numerics
                return new FileResult
                {
                    Valid = false,
                    Message = Messages.CannotHaveNonNumerics
                };
            }
            return new FileResult
            {
                Valid = true,
                HouseNumbers = houseNumbers
            };
        }
    }
}
