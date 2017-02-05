using System;
using PaperRound.Core;
using Xunit;

namespace PaperRound.Specs.Specification
{
    [Trait("The specification file does not exist", "")]
    public class FileDoesNotExist
    {
        private readonly StreetSpecificationParser _parser;
        public FileDoesNotExist()
        {
            _parser = new StreetSpecificationParser();
        }
        [Fact(DisplayName = "The parser throws an Argument Exception")]
        private void ParserThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _parser.ParseStreetSpecification(string.Empty));
        }
    }
}
