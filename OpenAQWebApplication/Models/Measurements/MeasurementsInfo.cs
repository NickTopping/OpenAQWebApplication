using OpenAQ.Models.Measurements;

namespace OpenAQ
{
    public class MeasurementsInfo
    {
        public MeasurementsInfo() { }
        public string Location { get; set; }
        public string Parameter { get; set; }
        public MeasurementsDate Date { get; set; }
        public float Value { get; set; }
        public string Unit { get; set; }
        public MeasurementsCoordinates Coordinates { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

}
