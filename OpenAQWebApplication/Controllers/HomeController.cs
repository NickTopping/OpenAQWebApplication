using OpenAQ;
using OpenAQ.Models.City;
using OpenAQ.Models.Country;
using OpenAQ.Models.Measurements;
using OpenAQWebApp.Models.Country;
using OpenAQWebApplication.Models.City;
using OpenAQWebApplication.ViewModels;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OpenAQWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var countryInfoList = GetCountriesRequest();
            var countryDropdownList = new List<SelectListItem>();

            foreach (var country in countryInfoList)
            {
                countryDropdownList.Add(new SelectListItem() { Text = country.Name, Value = country.Code });
            }

            CountryModel countryModel = new CountryModel
            {
                CountryInfo = countryInfoList,
                CountryDropdownItems = countryDropdownList
            };

            //Make dynamic from countries index change event
            var selectedCountryCode = GetCountriesRequest()?.First()?.Code; //Algeria
            var cityInfoList = GetCitiesRequest(selectedCountryCode);
            var cityDropdownList = new List<SelectListItem>();

            foreach (var city in cityInfoList)
            {
                cityDropdownList.Add(new SelectListItem() { Text = city.City, Value = city.City });
            }

            CityModel cityModel = new CityModel
            {
                CityInfo = cityInfoList,
                CityDropdownItems = cityDropdownList
            };

            AreaSelectionViewModel areaSelectionViewModel = new AreaSelectionViewModel()
            {
                CountryModel = countryModel,
                CityModel = cityModel
            };

            return View(areaSelectionViewModel);
        }

        public static List<CountryInfo> GetCountriesRequest() //Make private or move to Model?
        {
            var client = new RestClient("https://api.openaq.org/v1/countries");
            var request = ConfigureRequest();
            IRestResponse<CountryResult> response = client.Execute<CountryResult>(request);

            return response.Data.Results;
        }

        //Change to actionresult and remove static, return as partial view (will require repo and changes to Index()
        public static List<CityInfo> GetCitiesRequest(string countryCode) //Make private or move to Model?
        {
            //If countryCode is null popup "no country found"

            var client = new RestClient($"https://api.openaq.org/v1/cities?country={countryCode}&order_by=city");
            var request = ConfigureRequest();
            IRestResponse<CityResult> response = client.Execute<CityResult>(request);

            return response.Data.Results;
        }

        public static List<MeasurementsInfo> GetMeasurementsRequest(string cityName, string queryParameters = "", int limit = 100) //Make private or move to Model?
        {
            var client = new RestClient($"https://api.openaq.org/v1/measurements?city={cityName}&{queryParameters}&limit={limit}");
            var request = ConfigureRequest();
            IRestResponse<MeasurementsResult> response = client.Execute<MeasurementsResult>(request);

            return response.Data.Results;
        }

        private static RestRequest ConfigureRequest() //Move to Model?
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("accept-encoding", "gzip, deflate");
            request.AddHeader("Host", "api.openaq.org");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.15.0");

            return request;
        }
    }
}