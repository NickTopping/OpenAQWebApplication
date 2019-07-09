using OpenAQ;
using OpenAQ.Models.City;
using OpenAQ.Models.Country;
using OpenAQ.Models.Measurements;
using OpenAQWebApplication.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OpenAQWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AreaSelectionViewModel areaSelectionViewModel = new AreaSelectionViewModel();

            areaSelectionViewModel.CountryModel.CountryInfo = GetCountriesRequest();

            foreach (var country in areaSelectionViewModel.CountryModel.CountryInfo)
            {
                areaSelectionViewModel.CountryModel.CountryDropdownItems.Add(new SelectListItem() { Text = country.Name, Value = country.Code });
            }

            var selectedCountryCode = areaSelectionViewModel.CountryModel.SelectedCountryCode;

            areaSelectionViewModel.CityModel.CityInfo = GetCitiesRequest(selectedCountryCode);

            foreach (var city in areaSelectionViewModel.CityModel.CityInfo)
            {
                areaSelectionViewModel.CityModel.CityDropdownItems.Add(new SelectListItem() { Text = city.City, Value = city.City });
            }

            return View(areaSelectionViewModel);
        }

        public static List<CountryInfo> GetCountriesRequest()
        {
            var client = new RestClient("https://api.openaq.org/v1/countries");
            var request = ConfigureRequest();
            IRestResponse<CountryResult> response = client.Execute<CountryResult>(request);

            return response.Data.Results;
        }

        public static List<CityInfo> GetCitiesRequest(string countryCode)
        {
            var client = new RestClient($"https://api.openaq.org/v1/cities?country={countryCode}&order_by=city");
            var request = ConfigureRequest();
            IRestResponse<CityResult> response = client.Execute<CityResult>(request);

            return response.Data.Results;
        }

        public static List<MeasurementsInfo> GetMeasurementsRequest(string cityName, string queryParameters = "", int limit = 100)
        {
            var client = new RestClient($"https://api.openaq.org/v1/measurements?city={cityName}&{queryParameters}&limit={limit}");
            var request = ConfigureRequest();
            IRestResponse<MeasurementsResult> response = client.Execute<MeasurementsResult>(request);

            return response.Data.Results;
        }

        private static RestRequest ConfigureRequest()
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