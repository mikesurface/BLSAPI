namespace CPIService.Core
{
    public static class BlsValidator
    {
        public static bool IsValidSeriesId(string seriesId)
        {
            return !string.IsNullOrWhiteSpace(seriesId);
        }
    }
}
