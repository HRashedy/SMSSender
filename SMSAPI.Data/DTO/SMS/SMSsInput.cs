using SMSAPI.Data.Repositories.SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Data.DTO.SMS
{
    public class SMSsInput
    {
        private readonly ISMSsServise _smssRepository;
       

        public SMSsInput(ISMSsServise smssRepository)
        {
            this._smssRepository = smssRepository;
            
        }

        #region Properties
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        [Required]
        [StringLength(25)]
        public string Number { get; set; }
        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
        #endregion

        
    }
}
