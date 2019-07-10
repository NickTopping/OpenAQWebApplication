using OpenAQ;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public interface IMeasurementsRepository
    {
        List<MeasurementsInfo> GetMeasurementsRequest(string cityName, string queryParameters = "", int limit = 100);
    }
}