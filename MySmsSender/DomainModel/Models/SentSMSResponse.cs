using DomainModel.Values;
using ServiceStack.DataAnnotations;
using System;

namespace DomainModel
{
 
    public class SentSMSResponse
    {
        public string MCC { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public decimal Price { get; set; }
        public int CountryID { get; set; }

        public DateTime DateSent { get; set; }
        public  State State{ get;set; }
    }
}
