using System.Collections.Generic;

namespace OpenAQ.Models.City
{
    public class CityResult
    {
        public CityResult() { }
        public CityMeta CityMeta { get; set; }
        public List<CityInfo> Results { get; set; }
    }
}
