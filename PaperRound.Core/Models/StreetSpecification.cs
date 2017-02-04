namespace PaperRound.Core.Models
{
    public class StreetSpecification
    {
        public bool Valid { get; set; }
        public int LeftHouses { get; set; }
        public int RightHouses { get; set; }
        public int TotalHouses => LeftHouses + RightHouses;
        public string Message { get; set; }
    }
}
