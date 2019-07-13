using OpenAQ;
using OpenAQ.Models.Country;
using OpenAQWebApp.Controllers;
using OpenAQWebApplication.DataAccessLayer;
using RestSharp;
using System;
using System.Collections.Generic;

namespace OpenAQWebApplication.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        public List<CountryInfo> GetCountries()
        {
            try
            {
                var client = new RestClient("https://api.openaq.org/v1/countries");
                var request = HomeController.ConfigureRequest();
                IRestResponse<CountryResult> response = client.Execute<CountryResult>(request);

                return response.Data.results;
            }
            catch (Exception ex)
            {
                //Make custom CountryiesException class
                throw new Exception("Unable to retrieve Country data from the OpenAQ API:" + ex);
                //Log to event logger/DB
            }

        }
    }
}