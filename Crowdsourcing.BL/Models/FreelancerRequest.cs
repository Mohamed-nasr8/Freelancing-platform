using Crowdsourcing.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class FreelancerRequest
    {
        public int FreelancerId { get; set; } // Add this property

        public List<LanguageVM> Languages { get; set; }
        public List<EducationVM> Educations { get; set; }
        public List<ExpereinceVM> Expereinces { get; set; }

    }
}
