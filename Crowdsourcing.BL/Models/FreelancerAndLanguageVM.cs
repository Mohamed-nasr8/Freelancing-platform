using Crowdsourcing.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class FreelancerAndLanguageVM
    {

        public FreelancerVM Freelancer { get; set; }
        public List<LanguageVM> Languages { get; set; }
    }
}
