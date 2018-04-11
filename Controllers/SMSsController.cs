using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSAPI.Tree.DTO.SMS;
using SMSAPI.Tree.Entities;
using SMSAPI.Tree.Repositories.SMS;


namespace SMSAPI.Tree.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSsController : Controller
    {
        private readonly ISMSsRepository _SMSRepository;

        public SMSsController(ISMSsRepository SMSRepository)
        {
            _SMSRepository = SMSRepository;
        }

        #region APIs

        [HttpGet]
        public IActionResult GetSMSs()
        {
            var smss = _SMSRepository.Get();
            if (smss == null)
            {
                return NotFound();

            }
            return Ok(smss);

        }




        [HttpGet("{id?}")]
        public IActionResult GetSMS([FromRoute] string Id)
        {
           // return Ok(this._SMSRepository.Get(Id));
            var smss = this._SMSRepository.Get(Id);
                if (smss == null)
                {
                return NotFound();
                }
            return Ok(smss);
            

        }

        [HttpPost]
        
        public IActionResult CreateSMSs([FromBody]SMSs smssInput)
        {
            if (ModelState.IsValid)
            {
                this._SMSRepository.SendSMS(smssInput);
                this._SMSRepository.Create(smssInput);
                return CreatedAtAction("Get", new { id = smssInput.Id }, smssInput);
            }

            return BadRequest(ModelState);
        }
        #endregion
    }
}
