using DomainModel.Values;
using ServiceStack.DataAnnotations;
using System;

namespace DomainModel
{
  

    public class SMS
    {
        [AutoIncrement]
        [PrimaryKey]
        public int SmsID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public DateTime DateSent { get; set; }
        public State State { get; set; }
        public string MCC { get; set; }
        [References(typeof(Country))]
        public int CountryID { get; set; }
    }
}
