using System.Collections.Generic;
using System.Linq;

namespace PaperRound.Core.Models
{
    public class StreetSpecification
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public List<int> Houses { get; set; }
        public List<int> LeftHouses => Houses.Where(h => h % 2 != 0).ToList();
        public List<int> RightHouses => Houses.Where(h => h % 2 == 0).ToList();
    }
}
