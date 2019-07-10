using OpenAQ;
using OpenAQ.Models.Country;
using OpenAQWebApp.Controllers;
using OpenAQWebApplication.DataAccessLayer;
using RestSharp;
using System.Collections.Generic;

namespace OpenAQWebApplication.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        public List<CountryInfo> GetCountries()
        {
            var client = new RestClient("https://api.openaq.org/v1/countries");
            var request = HomeController.ConfigureRequest();
            IRestResponse<CountryResult> response = client.Execute<CountryResult>(request);

            return response.Data.Results;
        }
    }
}