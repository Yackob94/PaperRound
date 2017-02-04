using System.Collections.Generic;

namespace PaperRound.Core.Models
{
    public class FileResult
    {
        public bool Valid { get; set; }
        public StreetSpecification StreetSpecification { get; set; }
        public string Message { get; set; }

        public FileResult()
        {
            StreetSpecification = null;
            Valid = true;
        }
    }
}
