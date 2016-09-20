using ServiceStack;
using System;
using System.Collections.Generic;

namespace SMSApp.ServiceModel
{
    [Route("/sms/sent.json", Verbs = "GET")]
    public class SentSMSRequest
    {
        public string DateTimeFrom { get; set; }
        public string DateTimeTo { get; set; }
        public int Skip { get; set; }
        public int? Take { get; set; }
    }


    [Route("/sms/send.json", Verbs = "GET")]
    public class SendSMSRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
    }

    [Route("/statistics.json", Verbs = "GET")]
    public class StatisticsRequest
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public List<string> MCCList { get; set; }
    }

}