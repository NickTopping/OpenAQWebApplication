using OpenAQ;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenAQWebApplication.Models
{
    public class MeasurementsDTOModel
    {
        public MeasurementsDTOModel()
        {
            measurementsDTO = new List<MeasurementsDTO>();
            measurementsDTODropdownItems = new List<SelectListItem>();
        }

        public List<MeasurementsDTO> measurementsDTO { get; set; }
        public string selectedCityName { get; set; }
        public List<SelectListItem> measurementsDTODropdownItems { get; set; }
    }
}