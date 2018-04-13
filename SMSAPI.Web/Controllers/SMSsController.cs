using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSAPI.Data.DTO.SMS;
using SMSAPI.Data.Entities;
using SMSAPI.Data.Repositories.SMS;
using SMSAPI.App.Services.SMSsServices;


namespace SMSAPI.Tree.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSsController : Controller
    {
        private readonly ISMSsService _SMSServise;

        public SMSsController(ISMSsService SMSServise)
        {
            _SMSServise = SMSServise;
        }

        #region APIs

        [HttpGet]
        public IActionResult GetSMSs()
        {
            var smss = _SMSServise.GetAllsmss();
            if (smss == null)
            {
                return NotFound();

            }
            return Ok(smss);

        }




        [HttpGet("{id?}")]
        public IActionResult GetSMS([FromRoute] string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return this.BadRequest();

           // return Ok(this._SMSRepository.Get(Id));
            var smss = this._SMSServise.Getsmss(Id);
                if (smss == null)
                {
                return NotFound();
                }
            return Ok(smss);
            

        }

        [HttpPost]
        
        public IActionResult CreateSMSs([FromBody]SMSsInput smssInput)
        {
            if (ModelState.IsValid)
            {
                var sms = new SMSs() { Text = smssInput.Text, Number=smssInput.Number, ModifiedBy= smssInput.ModifiedBy,CreatedBy = smssInput.CreatedBy };
                this._SMSServise.SendSMS(sms);

                return this.Ok(sms);
            }

            return BadRequest(ModelState);
        }
        #endregion
    }
}
