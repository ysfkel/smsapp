using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace DomainModel
{
    public class Country
    {
        [AutoIncrement]
        [PrimaryKey]
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string MobileCode { get; set; }
        public string CountryCode { get; set; }
        public decimal PricePerSms { get; set; }
        public   List<SMS> SMS { get; set; }
    }
}
