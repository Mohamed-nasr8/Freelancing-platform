using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Helper
{
    public class PayoutRequest
    {
        public string Recipient { get; set; }
        public decimal Amount { get; set; }
    }
   

}
