using System;

namespace OpenAQ
{
    public class MeasurementsDTO
    {
        public string location { get; set; }
        public string parameter { get; set; }
        public float value { get; set; }
        public string unit { get; set; }
        public string utc { get; set; }
        public string local { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
