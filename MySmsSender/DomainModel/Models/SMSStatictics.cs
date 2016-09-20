using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class SMSStatictics
    {
        public DateTime Day { get; set; }
        public string MCC { get; set; }
        public decimal PricePerSMS { get; set; }
        public int Count { get; set; }
        public decimal ToTalPrice { get; set; }
    }
}
