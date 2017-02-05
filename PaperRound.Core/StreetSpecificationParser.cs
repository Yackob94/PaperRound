using PaperRound.Core.Models;
using System;
using System.Collections.Generic;
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

            List<int> houseNumbers;
            var fileResult = ValidateFile(filePath, out houseNumbers);

            if (!fileResult.Valid)
                return fileResult;

            // Validate the numbers
            fileResult.StreetSpecification = ValidateSpecification(houseNumbers);

            return fileResult;
        }

        private StreetSpecification ValidateSpecification(List<int> houseNumbers)
        {
            var oddNumbers = houseNumbers.Where(n => n % 2 != 0).ToList();
            var evenNumbers = houseNumbers.Where(n => n % 2 == 0).ToList();

            // Check to make sure each house only appears once
            if (!evenNumbers.SequenceEqual(evenNumbers.Distinct()) || !oddNumbers.SequenceEqual(oddNumbers.Distinct()))
            {
                return new StreetSpecification
                {
                    Valid = false,
                    Message = Messages.CannotBeRepeated
                };
            }

            var orderedEvenNumbers = evenNumbers.OrderBy(n => n).ToList();
            var orderedOddNumbers = oddNumbers.OrderBy(n => n).ToList();

            // Check there are no numbers in descending order
            if (!orderedEvenNumbers.SequenceEqual(evenNumbers) || !orderedOddNumbers.SequenceEqual(oddNumbers))
            {
                return new StreetSpecification
                {
                    Valid = false,
                    Message = Messages.CannotHaveDescendingNumbers
                };
            }

            var expectedEvenCount = orderedEvenNumbers.Last() / 2;
            var expectedOddCount = Math.Ceiling((double)orderedOddNumbers.Last() / 2);

            // If we have higher last number than the actual count
            // then a number has been missed
            if (expectedEvenCount > evenNumbers.Count || expectedOddCount > oddNumbers.Count)
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
                Houses = houseNumbers
            };
        }

        private FileResult ValidateFile(string filePath, out List<int> houseNumbers)
        {
            string specification;
            houseNumbers = null;

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

            try
            {
                // Parse the numbers
                houseNumbers = specArry.Select(int.Parse).ToList();
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
                Valid = true
            };
        }
    }
}
