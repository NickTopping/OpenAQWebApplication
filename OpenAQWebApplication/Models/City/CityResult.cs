using System.Collections.Generic;

namespace OpenAQ.Models.City
{
    public class CityResult
    {
        public CityResult() { }
        public CityMeta cityMeta { get; set; }
        public List<CityInfo> results { get; set; }
    }
}
