using OpenAQ;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenAQWebApplication.Models.City
{
    public class CityModel
    {
        public CityModel()
        {
            CityInfo = new List<CityInfo>();
            CityDropdownItems = new List<SelectListItem>();
        }

        public List<CityInfo> CityInfo { get; set; }
        public string SelectedCityName { get; set; }
        public List<SelectListItem> CityDropdownItems { get; set; }
    }
}