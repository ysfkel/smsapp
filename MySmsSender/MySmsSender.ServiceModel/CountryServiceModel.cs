using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsSender.ServiceModel
{
    public class CountryServiceModel
    {
        [Route("/countries.json", Verbs = "GET")]
        public class CountriesRequest
        {

        }
    }
}
