using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Tree.Entities
{
    public class SMSs : AuditEntity
    {
        // public int Id { get; set; }
        public SMSs() : base() { }
       
        #region Properties
        [Required]
        [StringLength(25, MinimumLength = 10)] 
        public string Number { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Text { get; set; }
        #endregion
    }
}