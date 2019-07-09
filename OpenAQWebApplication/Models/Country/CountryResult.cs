using System.Collections.Generic;

namespace OpenAQ.Models.Country
{
    public class CountryResult
    {
        public CountryResult() { }
        public CountryMeta CountryMeta { get; set; }
        public List<CountryInfo> Results { get; set; }
    }
}
