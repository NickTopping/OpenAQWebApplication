using OpenAQ;
using System.Collections.Generic;

namespace OpenAQWebApplication.DataAccessLayer
{
    public interface ICountriesRepository
    {
        List<CountryInfo> GetCountries();
    }
}