using Microsoft.EntityFrameworkCore;
using SMSAPI.Data.Entities;
using System.Linq;


namespace SMSAPI.Data.Repositories.SMS
{
    public class SMSsRepository : GenericRepository<SMSs>, ISMSsServise
    {
        public SMSsRepository(DbContext context) : base(context) { }
        public override SMSs Get(string id)
        {
            return this._dbset.FirstOrDefault(x => x.Id == id);
        }


    }
}
