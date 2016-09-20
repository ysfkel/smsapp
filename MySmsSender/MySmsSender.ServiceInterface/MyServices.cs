using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using MySmsSender.ServiceModel;
using ApplicationService;
using DomainModel;
using static MySmsSender.ServiceModel.CountryServiceModel;
using SMSApp.ServiceModel;
using DomainModel.Models;
using System.Threading.Tasks;

namespace MySmsSender.ServiceInterface
{
    public class MyServices : Service
    {
        private SMSAppicationService<SMS> repo;
        private CountryService<Country> countriesRepo;

        public MyServices()
        {
            this.countriesRepo = new CountryService<Country>(Db);
            this.repo = new SMSAppicationService<SMS>(Db, countriesRepo,new SMSService());
        }

        public List<Country> Get(CountriesRequest resquest)
        {
            return countriesRepo.Get();
        }

        public List<SMSStatictics> Get(StatisticsRequest request)
        {
            return repo.GetStatisticks(request.DateFrom,request.DateTo, request.MCCList);
        }

        public List<SMS> Get(SentSMSRequest request)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            return repo.GetSentSms(request.DateTimeFrom, request.DateTimeTo, request.Skip, request.Take, format);
        }

        public async Task<int> Get(SendSMSRequest request)
        {
            return await repo.SendAsync(request.From, request.To, request.Text);
        }
    }
}