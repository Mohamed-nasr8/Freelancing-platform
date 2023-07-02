using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Interface
{
    public interface IPaymentRepository
    {
        Task<string> CreateConnectedAccount(int freelancerId);

    }
}
