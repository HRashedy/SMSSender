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
        public SMSs Get(string smsId)
        {
            return this._SMSRepository.Get(smsId);
        }

        [HttpPost]
        
        public IActionResult CreateSMSs([FromBody]SMSs smssInput)
        {
            if (ModelState.IsValid)
            {
                this._SMSRepository.Create( smssInput);
                this._SMSRepository.SendSMS(smssInput);
            }

            return RedirectToAction(nameof(Get), "SMSs", null);
        }
        #endregion
    }
}
