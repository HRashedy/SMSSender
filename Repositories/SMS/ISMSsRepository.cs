using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMSAPI.Tree.Entities;

namespace SMSAPI.Tree.Repositories.SMS
{
    public interface ISMSsRepository : IGenericRepository<SMSs>
    {
        new int Create(SMSs SMSs);
        new IEnumerable<SMSs> Get();
        new SMSs Get(string id);
        string SendSMS(SMSs SMSVal);
        IActionResult FirstOrDefault(Func<object, bool> p);

    }
}
