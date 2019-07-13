using OpenAQ;
using OpenAQ.Models.Measurements;
using OpenAQWebApp.Controllers;
using RestSharp;
using System;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public class MeasurementsRepository : IMeasurementsRepository
    {
        public List<MeasurementsInfo> GetMeasurementsRequest(string cityName, string queryParameters, int limit)
        {
            try
            {
                var client = new RestClient($"https://api.openaq.org/v1/measurements?city={cityName}&{queryParameters}&limit={limit}");
                var request = HomeController.ConfigureRequest();
                IRestResponse<MeasurementsResult> response = client.Execute<MeasurementsResult>(request);

                return response.Data.results;
            }
            catch (Exception ex)
            {
                //Make custom MeasurementsException class
                throw new Exception("Unable to retrieve Measurements data from the OpenAQ API:" + ex);
                //Log to event logger/DB
            }
        }
    }
}