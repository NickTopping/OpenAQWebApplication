using System;

namespace OpenAQ
{
    public class MeasurementsDTO
    {
        public string Location { get; set; }
        public string Parameter { get; set; }
        public float Value { get; set; }
        public string Unit { get; set; }
        public DateTime Utc { get; set; }
        public DateTime Local { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
