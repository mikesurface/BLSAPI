using System.Text;

namespace CPIService.Model
{
    public class BlsDataPoint
    {
        public BlsDataPoint()
        {
            Footnotes = new List<BlsFootnote>();
        }
        public string Year { get; set; }
        public string Period { get; set; }
        public string PeriodName { get; set; }
        public string Value { get; set; }
        public string Latest { get; set; }
        public List<BlsFootnote> Footnotes { get; set; }

        // Calculated Property
        public int ValueAsInt
        {
            get
            {
                var returnValue = 0;
                int.TryParse(Value, out returnValue);
                return returnValue;
            }
        }

        // Calculated Property
        public string Notes
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var note in Footnotes)
                {
                    sb.AppendFormat("Code: {0} - Text: {1}", note.Code, note.Text);
                }

                return sb.ToString();
            }
        }
    }
}