using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAQ.Models.Country
{
    public class CountryMeta
    {
        public CountryMeta() { }
        public string Name { get; set; }
        public string License { get; set; }
        public string Website { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int Found { get; set; }
    }
}
