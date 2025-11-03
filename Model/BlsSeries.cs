namespace CPIService.Model
{
    public class BlsSeries
    {
        public BlsSeries()
        {
            Data = new List<BlsDataPoint>();
        }
        public string SeriesID { get; set; }
        public List<BlsDataPoint> Data { get; set; }
    }
}