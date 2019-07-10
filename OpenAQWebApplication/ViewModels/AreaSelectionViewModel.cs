using OpenAQWebApplication.Models;

namespace OpenAQWebApplication.ViewModels
{
    public class AreaSelectionViewModel
    {
        public CountryModel countryModel { get; set; }
        public CityModel cityModel { get; set; }
        public MeasurementsDTOModel measurementsDTOModel { get; set; }
    }
}