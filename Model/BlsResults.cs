namespace CPIService.Model
{
    public class BlsResults
    {
        public BlsResults()
        {
            Series = new List<BlsSeries>();
        }
        public List<BlsSeries> Series { get; set; }
    }
}