using System.Collections.Generic;

namespace OpenAQ.Models.Measurements
{
    public class MeasurementsResult
    {
        public MeasurementsResult() { }
        public MeasurementsMeta Meta { get; set; }
        public List<MeasurementsInfo> Results { get; set; }
    }
}
