using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSAPI.Tree.Context;
using SMSAPI.Tree.Entities;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSAPI.Tree.Repositories.SMS
{
    public class SMSsRepository : GenericRepository<SMSs>, ISMSsRepository
    {

        public SMSsRepository(DbContext context) : base(context) { }
      
        public int Create(SMSs SMSs)
        {
            this._dbset.Add(SMSs);
            return this._entities.SaveChanges();
        }

        public IActionResult FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SMSs> Get()
        {
            return this._dbset.Include(x => x.Id);
        }

        public override SMSs Get(string id)
        {
            return this._dbset.FirstOrDefault(x => x.Id == id);
        }

        public string SendSMS(SMSs SMSVal)
        {
            //var TwilioInfo = Configuration.GetSection("TwilioInfo");
            const string accountSid = "AC0ebfc71733b1476cd56ccb057082d685";
            const string authToken = "5545517edf7c3806d48b035d1760ab38";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(SMSVal.Number);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+19387777010"),
                body: SMSVal.Text);

            return "Sent";
      
        }
    }
}
