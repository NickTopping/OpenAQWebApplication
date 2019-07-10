﻿using OpenAQWebApplication.DataAccessLayer;
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

            foreach (var country in countryInfoList)
            {
                countryDropdownList.Add(new SelectListItem() { Text = country.Name, Value = country.Code });
            }

            CountryModel countryModel = new CountryModel
            {
                countryInfo = countryInfoList,
                countryDropdownItems = countryDropdownList
            };

            //Make dynamic from countries index change event
            var selectedCountryCode = _countriesRepository.GetCountries()?.First()?.Code; //Algeria
            var cityInfoList = _citiesRepository.GetCitiesRequest(selectedCountryCode);
            var cityDropdownList = new List<SelectListItem>();

            foreach (var city in cityInfoList)
            {
                cityDropdownList.Add(new SelectListItem() { Text = city.City, Value = city.City });
            }

            CityModel cityModel = new CityModel
            {
                cityInfo = cityInfoList,
                cityDropdownItems = cityDropdownList
            };

            var selectedCityName = cityInfoList.FirstOrDefault().City;
            var measurementsDTOList = _measurementsRepository.GetMeasurementsRequest(selectedCityName);

            AreaSelectionViewModel areaSelectionViewModel = new AreaSelectionViewModel()
            {
                countryModel = countryModel,
                cityModel = cityModel
            };

            return View(areaSelectionViewModel);
        }

        //Change to actionresult and remove static, return as partial view (will require repo and changes to Index()
        //Call repository (with this method inside) in new method here that uses action result
        public ActionResult GetCountriesRequest()
        {
            return PartialView(_countriesRepository.GetCountries());
        }

        public ActionResult GetCitiesRequest(string countryCode)
        {
            return PartialView(_citiesRepository.GetCitiesRequest(countryCode));
        }

        public ActionResult GetMeasurementsRequest(string cityName, string queryParameters = "", int limit = 100)
        {
            return PartialView(_measurementsRepository.GetMeasurementsRequest(cityName, queryParameters, limit));
        }

        public static RestRequest ConfigureRequest() //Move? Consumed by all repositories.
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