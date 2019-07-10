using OpenAQ.Models.Measurements;

namespace OpenAQ
{
    public class MeasurementsInfo
    {
        public MeasurementsInfo() { }
        public string location { get; set; }
        public string parameter { get; set; }
        public MeasurementsDate date { get; set; }
        public float value { get; set; }
        public string unit { get; set; }
        public MeasurementsCoordinates coordinates { get; set; }
        public string country { get; set; }
        public string city { get; set; }
    }

}
