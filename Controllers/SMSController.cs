using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendSMS.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendSMS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SMSController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<SMS> GetSMSs()
        {
            return _context.SMSs;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSMSs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smsVal = await _context.SMSs.SingleOrDefaultAsync(m => m.Id == id);

            if (smsVal == null)
            {
                return NotFound();
            }

            return Ok(smsVal);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostSMSs([FromBody]SMS sms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.SMSs.Add(sms);
            await _context.SaveChangesAsync();


            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "AC0ebfc71733b1476cd56ccb057082d685";
            const string authToken = "5545517edf7c3806d48b035d1760ab38";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(sms.Number);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+19387777010"),
                body: sms.Text);
           
            return CreatedAtAction("GetSMSs", new { id = sms.Id }, sms);
           // return  message.AccountSid;
        }
    }
}