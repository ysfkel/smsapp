using DomainModel;
using DomainModel.Repository;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationService
{
    public interface ICountryService<T>:  IGenericRepository<T> where T : DomainModel.Country
    {
         Country GetCountryByCountryCode(string countryCode);

        Country GetCountryByMobileCountryCode(string mobileCountryCode);

        string GetCountryCodeFromMobileNumber(string mobileNumber);



        List<Country> GetCountryByModelCountryCode(List<string> MobileCountryCodes);

    }
}
