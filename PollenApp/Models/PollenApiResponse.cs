namespace PollenApp.Models
{
    public class PollenApiResponse
    {
        public MetaData _meta { get; set; }
        public List<Link> _links { get; set; }
        public List<PollenType> items { get; set; }
    }

    public class MetaData
    {
        public int totalRecords { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
    }

    public class PollenType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string forecasts { get; set; }
        public int? thresholdLow { get; set; }
        public int? thresholdMedium { get; set; }
        public int? thresholdHigh { get; set; }
        public int? thresholdVeryHigh { get; set; }
    }
}
