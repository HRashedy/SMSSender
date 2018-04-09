using SMSSendAPI.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSSendAPI.Data.Interfaces
{
    public class ISMSRepository
    {
       public IEnumerable<SMS> SMSs { get; }
        //public IEnumerable<SMS> SendSMS { get; set; }
        public void SendSMS(SMS smsval) {  }
    

    }
}
