namespace CPIService.Core
{
    public static class DateValidator
    {
        private static readonly HashSet<string> ValidMonths = new()
    {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };

        public static bool IsValidYear(string year)
        {
            return int.TryParse(year, out int y) && y >= 1900 && y <= DateTime.UtcNow.Year;
        }

        public static bool IsValidMonth(string month)
        {
            return ValidMonths.Contains(month, StringComparer.OrdinalIgnoreCase);
        }
    }
}
