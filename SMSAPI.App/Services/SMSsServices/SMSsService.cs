using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SMSAPI.App.OptionModels;
using SMSAPI.Data.DTO.SMS;
using SMSAPI.Data.Entities;
using SMSAPI.Data.Repositories.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSAPI.App.Services.SMSsServices
{
    public class SMSsService : ISMSsService
    {
        private TwilioConfig _twilioConfig;
        private readonly ISMSsServise _SMSRepository;

        public SMSsService(DbContext context, ISMSsServise SMSRepository, IOptions<TwilioConfig> TwilioConfig) : base()
        {
            this._twilioConfig = TwilioConfig.Value;
            this._SMSRepository = SMSRepository;
        }
        public string SendSMS(SMSs SMSVals)
        {
            //var TwilioInfo = Configuration.GetSection("TwilioInfo");
            // const string accountSid = "AC0ebfc71733b1476cd56ccb057082d685";
            // const string authToken = "5545517edf7c3806d48b035d1760ab38";
            TwilioClient.Init(this._twilioConfig.AccountSid, this._twilioConfig.AuthToken);

            var to = new PhoneNumber(SMSVals.Number);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+19387777010"),
                body: SMSVals.Text);

            this._SMSRepository.Create(SMSVals);

            return "Sent";

        }


        public IEnumerable<SMSs> GetAllsmss()
        {
            return this._SMSRepository.Get();
        }

        public SMSs Getsmss(string id)
        {
            return this._SMSRepository.Get(id);
        }
    }
}
