using OpenAQ;
using OpenAQ.Models.Measurements;
using OpenAQWebApp.Controllers;
using RestSharp;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public class MeasurementsRepository : IMeasurementsRepository
    {
        public List<MeasurementsInfo> GetMeasurementsRequest(string cityName, string queryParameters = "", int limit = 100)
        {
            var client = new RestClient($"https://api.openaq.org/v1/measurements?city={cityName}&{queryParameters}&limit={limit}");
            var request = HomeController.ConfigureRequest();
            IRestResponse<MeasurementsResult> response = client.Execute<MeasurementsResult>(request);

            return response.Data.results;
        }
    }
}