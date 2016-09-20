using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
   public class SMSStatisticsInput
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public decimal PricePerSMS { get; set; }
        public DateTime DateSent { get; set; }
        public string MCC { get; set; }

    }
}
