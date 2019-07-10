using OpenAQ;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public interface ICitiesRepository
    {
        List<CityInfo> GetCitiesRequest(string countryCode);
    }
}