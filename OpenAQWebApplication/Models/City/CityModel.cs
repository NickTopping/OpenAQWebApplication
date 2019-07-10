using OpenAQ;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenAQWebApplication.Models
{
    public class CityModel
    {
        public CityModel()
        {
            cityInfo = new List<CityInfo>();
            cityDropdownItems = new List<SelectListItem>();
        }

        public List<CityInfo> cityInfo { get; set; }
        public string selectedCityName { get; set; }
        public List<SelectListItem> cityDropdownItems { get; set; }
    }
}