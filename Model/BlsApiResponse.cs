namespace CPIService.Model
{
    public class BlsApiResponse
    {
        public BlsApiResponse()
        {
            Message = new List<string>();
        }
        public string Status { get; set; }
        public int ResponseTime { get; set; }
        public List<string> Message { get; set; }
        public BlsResults Results { get; set; }
    }
}