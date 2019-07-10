using OpenAQ;
using System.Collections.Generic;

namespace OpenAQWebApplication.Models
{
    public class MeasurementsDTOModel
    {
        public MeasurementsDTOModel()
        {
            measurementsDTO = new List<MeasurementsDTO>();
        }

        public List<MeasurementsDTO> measurementsDTO { get; set; }
        public string selectedCityName { get; set; }
    }
}