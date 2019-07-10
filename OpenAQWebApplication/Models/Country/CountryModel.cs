using OpenAQ;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenAQWebApplication.Models
{
    public class CountryModel
    {
        public CountryModel()
        {
            countryInfo = new List<CountryInfo>();
            countryDropdownItems = new List<SelectListItem>();
        }

        public List<CountryInfo> countryInfo { get; set; }
        public string selectedCountryCode { get; set; }
        public List<SelectListItem> countryDropdownItems { get; set; }
    }
}