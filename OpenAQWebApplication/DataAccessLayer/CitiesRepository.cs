using OpenAQ;
using OpenAQ.Models.City;
using OpenAQWebApp.Controllers;
using RestSharp;
using System;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public class CitiesRepository : ICitiesRepository
    {
        public List<CityInfo> GetCitiesRequest(string countryCode)
        {
            try
            {
                var client = new RestClient($"https://api.openaq.org/v1/cities?country={countryCode}&order_by=city");
                var request = HomeController.ConfigureRequest();
                IRestResponse<CityResult> response = client.Execute<CityResult>(request);

                return response.Data.results;
            }
            catch(Exception ex)
            {
                //Make custom CitiesException class
                throw new Exception("Unable to retrieve City data from the OpenAQ API:" + ex);
                //Log to event logger/DB
            }
        }
    }
}