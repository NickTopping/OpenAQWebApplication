using OpenAQ.Mappers;
using OpenAQWebApplication.DataAccessLayer;
using OpenAQWebApplication.Models;
using OpenAQWebApplication.Repositories;
using OpenAQWebApplication.ViewModels;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OpenAQWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ICountriesRepository _countriesRepository;
        private ICitiesRepository _citiesRepository;
        private IMeasurementsRepository _measurementsRepository;

        public HomeController()
        {
            _countriesRepository = new CountriesRepository();
            _citiesRepository = new CitiesRepository();
            _measurementsRepository = new MeasurementsRepository();
        }

        public ActionResult Index()
        {
            var countryInfoList = _countriesRepository.GetCountries();
            var countryDropdownList = new List<SelectListItem>();

            if (countryInfoList != null)
            {
                foreach (var country in countryInfoList)
                {
                    countryDropdownList.Add(new SelectListItem() { Text = country.name, Value = country.code });
                }
            }

            CountryModel countryModel = new CountryModel
            {
                countryInfo = countryInfoList,
                countryDropdownItems = countryDropdownList
            };

            var selectedCountryCode = _countriesRepository.GetCountries()?.First()?.code; //Algeria
            var cityInfoList = _citiesRepository.GetCitiesRequest(selectedCountryCode);
            var cityDropdownList = new List<SelectListItem>();

            if (cityInfoList != null)
            {
                foreach (var city in cityInfoList)
                {
                    cityDropdownList.Add(new SelectListItem() { Text = city.city, Value = city.city });
                }
            }

            CityModel cityModel = new CityModel
            {
                cityInfo = cityInfoList,
                cityDropdownItems = cityDropdownList
            };

            var selectedCityName = cityInfoList.FirstOrDefault().city;
            var measurementsInfoList = _measurementsRepository.GetMeasurementsRequest(selectedCityName);
            var measurementsDTOList = MeasurementsMapper.MapMeasurements(measurementsInfoList);

            MeasurementsDTOModel measurementsDTOModel = new MeasurementsDTOModel
            {
                measurementsDTO = measurementsDTOList
            };

            AreaSelectionViewModel areaSelectionViewModel = new AreaSelectionViewModel()
            {
                countryModel = countryModel,
                cityModel = cityModel,
                measurementsDTOModel = measurementsDTOModel
            };

            return View(areaSelectionViewModel);
        }

        //public ActionResult GetCountriesRequest() //unused
        //{
        //    return PartialView(_countriesRepository.GetCountries());
        //}

        public ActionResult GetCitiesRequest(string countryCode)
        {
            return Json(_citiesRepository.GetCitiesRequest(countryCode), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMeasurementsRequest(string cityName, string queryParameters = "", int limit = 100)
        {
            var measurementsInfoList = _measurementsRepository.GetMeasurementsRequest(cityName, queryParameters: queryParameters, limit: limit);
            var measurementsDTOList = MeasurementsMapper.MapMeasurements(measurementsInfoList);

            return Json(measurementsDTOList, JsonRequestBehavior.AllowGet);
        }

        public static RestRequest ConfigureRequest()
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