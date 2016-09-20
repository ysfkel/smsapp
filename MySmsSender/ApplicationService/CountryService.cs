using DomainModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class CountryService<T>: Decorator<T>,ICountryService<T> where T : DomainModel.Country
    {
        public CountryService(IDbConnection Db) : base(Db)
        {

        }


        public Country GetCountryByCountryCode(string countryCode)
        {
           return Get().Where(x => x.CountryCode == countryCode).Single();
        }

        public Country GetCountryByMobileCountryCode(string code)
        {
           return Get().Where(x => x.MobileCode == code).SingleOrDefault();
        }

        public Country GetCountryByModelCountryCode(string MobileCountryCode)
        {
            return Get().Where(x => x.MobileCode == MobileCountryCode).Single();
        }

        public List<Country> GetCountryByModelCountryCode(List<string> MobileCountryCodes)
        {
            List<Country> countries = new List<Country>();
            foreach(var mcc in MobileCountryCodes)
            {
                countries.Add(GetCountryByModelCountryCode(mcc));
            }
            return countries;
        }


        public string GetCountryCodeFromMobileNumber(string mobileNumber)
        {
            return mobileNumber.Substring(0, mobileNumber.IndexOf("-"));
        }

    }
}
