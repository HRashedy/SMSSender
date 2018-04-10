using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI.Tree.Entities
{
    public class AuditEntity : BaseEntity
    {
        public AuditEntity() : base()
        {
            this.Created = DateTime.Now;
            this.Modified = DateTime.Now;
        }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
