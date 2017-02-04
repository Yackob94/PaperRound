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

            string specification;

            // Read the first line
            using (var reader = new StreamReader(filePath))
                specification = reader.ReadLine();

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

            var oddNumbers = houseNumbers.Where(n => n % 2 != 0).ToArray();
            var evenNumbers = houseNumbers.Where(n => n % 2 == 0).ToArray();

            // Validate the numbers
            var fileResult = ValidateSpecification(oddNumbers, evenNumbers);

            // If it's valid create and assign the specification for the report
            if (fileResult.Valid)
                fileResult.StreetSpecification = new StreetSpecification(oddNumbers.Length, evenNumbers.Length);

            return fileResult;
        }

        private FileResult ValidateSpecification(int[] oddNumbers, int[] evenNumbers)
        {
            var fileResult = new FileResult();

            var evenNumberCount = evenNumbers.Length;
            var oddNumberCount = oddNumbers.Length;

            var distinctEvenNumberCount = evenNumbers.Distinct().Count();
            var distinctOddNumberCount = oddNumbers.Distinct().Count();

            // Check to make sure each house only appears once
            if (distinctEvenNumberCount != evenNumberCount || distinctOddNumberCount != oddNumberCount)
            {
                fileResult.Valid = false;
                fileResult.Message = Messages.CannotBeRepeated;
                return fileResult;
            }

            var orderedEvenNumbers = evenNumbers.OrderBy(n => n);
            var orderedOddNumbers = oddNumbers.OrderBy(n => n);

            var expectedEvenCount = orderedEvenNumbers.Last() / 2;
            var expectedOddCount = Math.Ceiling((double)orderedOddNumbers.Last() / 2);

            // If we have higher last number than the actual count
            // then a number has been missed
            if (expectedEvenCount > evenNumberCount || expectedOddCount > oddNumberCount)
            {
                fileResult.Valid = false;
                fileResult.Message = Messages.CannotBeSkipped;
            }

            return fileResult;
        }
    }
}
