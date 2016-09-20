

using DomainModel;
using DomainModel.Models;
using DomainModel.Repository;
using DomainModel.Values;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class SMSAppicationService<T> : Decorator<T> where T : SMS
    {
        private ICountryService<Country> countryService;
        private ISMSService smsService;
        public SMSAppicationService(IDbConnection Db, ICountryService<Country> countryService, ISMSService smsService) : base(Db)
        {
            this.countryService = countryService;
            this.smsService = smsService;
        }

        private string FormatDateToString(DateTime date)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            return date.ToString(format);
        }

        private bool FormatStringToDate(string date_str, string format, out DateTime date)
        {
            return DateTime.TryParseExact(date_str, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        public async Task<int> SendAsync(string From, string To, string Text)
        {
            string countryCode = countryService.GetCountryCodeFromMobileNumber(To);
            Country country = countryService.GetCountryByCountryCode(countryCode);


            var sms = new SMS
            {
                CountryID = country.CountryID,
                MCC = country.MobileCode,
                DateSent = DateTime.Now,
                From = From,
                To = To,
                Price = country.PricePerSms,
                State = State.Success,
                Text = Text
            };
            
             await smsService.SendAsync(sms);


            return await SaveSentSMSAsync(sms);


        }


         public List<T> GetSentSms(string dateTimeFrom, string dateTimeTo, int skip, int? take, string format)
        {
          return  GetSentSmsByParams(dateTimeFrom, dateTimeTo, skip, take, format);
        }


        private List<T> GetSentSmsByParams(string dateTimeFrom, string dateTimeTo, int skip, int? take, string format)
        {
            var smsList = Get();

            if (dateTimeFrom != null)
            {
                DateTime date;
                if (FormatStringToDate(dateTimeFrom, format, out date))
                {
                    smsList = smsList.Where(x => x.DateSent >= date).ToList();
                }
            }
            if (dateTimeTo != null)
            {
                DateTime date;
                if (FormatStringToDate(dateTimeTo, format, out date))
                {
                    smsList = smsList.Where(x => x.DateSent <= date).ToList();
                }
            }

            smsList = smsList.Skip(skip).ToList();

            if (take != null)
            {
                smsList = smsList.Take((int)take).ToList();
            }
            

            return smsList;
        }

        public List<SMSStatictics> GetStatisticks(string dateFrom, string dateTo, List<string> mccList)
        {
            string format = "yyyy-MM-dd HH:mm:ss";

            var smsList = GetSentSmsByParams(dateFrom, dateTo, 0, null, format);
            if (mccList != null)
            {
                List<T> filteredSMS = new List<T>();
                foreach (var mcc in mccList)
                {
                    var country = countryService.GetCountryByMobileCountryCode(mcc);
                    if (country != null)
                    {
                        filteredSMS.AddRange(FilterSMSByCountryID(smsList,country));
                    }

                }
               
                smsList = filteredSMS; ;
            }

            var statistics = ComputeStatistics(smsList);

            return statistics;

        }

        private List<T> FilterSMSByCountryID(List<T> smsList,Country country)
        {
            return smsList.Where(x => x.CountryID == country.CountryID).ToList();
        }

        private async Task<int> SaveSentSMSAsync(SMS sms)
        {
            return await Task.Run(()=> base.Add(sms as T));
        }

        private List<SMSStatictics> ComputeStatistics(List<T> input)
        {
            var statistics = input.GroupBy(x => new { x.DateSent }).Select(g => new SMSStatictics
            {
                ToTalPrice = g.Sum(x => x.Price),
                MCC = g.First().MCC,
                Day = g.Key.DateSent,
                PricePerSMS = g.First().Price,
                Count = g.Count()
            }).ToList();

            return statistics;
        }

     

    }



}
