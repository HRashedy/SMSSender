using SMSAPI.Data.Entities;
using System.Collections.Generic;

namespace SMSAPI.App.Services.SMSsServices
{
    public interface ISMSsService
    {
        string SendSMS(SMSs SMSVal);
        SMSs Getsmss(string id);
        IEnumerable<SMSs> GetAllsmss();
    }
}
