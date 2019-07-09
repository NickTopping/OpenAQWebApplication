using OpenAQ;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenAQWebApp.Models.Country
{
    public class CountryModel
    {
        public CountryModel()
        {
            CountryInfo = new List<CountryInfo>();
            CountryDropdownItems = new List<SelectListItem>();
        }

        public List<CountryInfo> CountryInfo { get; set; }
        public string SelectedCountryCode { get; set; }
        public List<SelectListItem> CountryDropdownItems { get; set; }
    }
}