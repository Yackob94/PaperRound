namespace PaperRound.Core.Models
{
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
}
