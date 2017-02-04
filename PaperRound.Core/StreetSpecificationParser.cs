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
            var oddNumbers = houseNumbers.Where(n => n % 2 != 0).ToArray();
            var evenNumbers = houseNumbers.Where(n => n % 2 == 0).ToArray();

            var fileResult = ValidateSpecification(oddNumbers, evenNumbers);

            if (fileResult.Valid)
            {
                fileResult.StreetSpecification = new StreetSpecification(oddNumbers.Count(), evenNumbers.Count());
            }

            return fileResult;
        }

        private FileResult ValidateSpecification(int[] oddNumbers, int[] evenNumbers)
        {
            var fileResult = new FileResult();
            var orderedEvenNumbers = evenNumbers.OrderBy(n => n);
            var orderedOddNumbers = oddNumbers.OrderBy(n => n);

            if (orderedEvenNumbers.Last() / 2 != orderedEvenNumbers.Count() ||
                Math.Ceiling((double)orderedOddNumbers.Last() / 2) != orderedOddNumbers.Count())
            {
                fileResult.Valid = false;
                fileResult.Message = Messages.CannotBeSkipped;
            }

            return fileResult;
        }
    }
}
