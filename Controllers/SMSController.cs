using Microsoft.AspNetCore.Mvc;
using SMSSendAPI.Data.Interfaces;
using SMSSendAPI.Data.Model;
using SMSSendAPI.Data.Repository;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSSendAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSController : Controller
    {
        private readonly ISMSRepository _SMSRepository;

        public SMSController(ISMSRepository SMSRepository)
        {
            _SMSRepository = SMSRepository;
        }

         
        // POST api/
        [HttpPost]
        public string PostSMSs([FromBody]SMS sms)
        {
            if (ModelState.IsValid)
            {
                _SMSRepository.SendSMS(sms);

            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "AC0ebfc71733b1476cd56ccb057082d685";
            const string authToken = "5545517edf7c3806d48b035d1760ab38";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(sms.Number);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+19387777010"),
                body: sms.Text);

            return "Sent";
            }
            return "Not sent!!";
            // return  message.AccountSid;
        }


    }
}