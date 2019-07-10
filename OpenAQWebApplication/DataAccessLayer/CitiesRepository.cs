using OpenAQ;
using OpenAQ.Models.City;
using OpenAQWebApp.Controllers;
using RestSharp;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public class CitiesRepository : ICitiesRepository
    {
        public List<CityInfo> GetCitiesRequest(string countryCode)
        {
            //If countryCode is null popup "no country found"

            var client = new RestClient($"https://api.openaq.org/v1/cities?country={countryCode}&order_by=city");
            var request = HomeController.ConfigureRequest();
            IRestResponse<CityResult> response = client.Execute<CityResult>(request);

            return response.Data.results;
        }
    }
}