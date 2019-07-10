using System.Collections.Generic;

namespace OpenAQ.Models.Measurements
{
    public class MeasurementsResult
    {
        public MeasurementsResult() { }
        public MeasurementsMeta meta { get; set; }
        public List<MeasurementsInfo> results { get; set; }
    }
}
