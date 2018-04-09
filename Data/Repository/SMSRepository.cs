using SMSSendAPI.Data.Interfaces;
using SMSSendAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSSendAPI.Data.Repository
{
    public class SMSRepository : ISMSRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SMSRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<SMS> SMSs => _applicationDbContext.SMSs;


        public void SendSMS(SMS smsval)
        {
            smsval.CreatedUtc = DateTime.Now;

            _applicationDbContext.SMSs.Add(smsval);

            _applicationDbContext.SaveChanges();
        }
    }
}
