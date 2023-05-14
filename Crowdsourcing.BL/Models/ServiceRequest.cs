using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class ServiceRequest
    {
        public ServiceVM Service { get; set; }
        public List<ServiceSkillsVM> ServiceSkills { get; set; }


    }
}
