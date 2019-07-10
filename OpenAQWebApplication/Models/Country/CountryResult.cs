using System.Collections.Generic;

namespace OpenAQ.Models.Country
{
    public class CountryResult
    {
        public CountryResult() { }
        public CountryMeta countryMeta { get; set; }
        public List<CountryInfo> results { get; set; }
    }
}
