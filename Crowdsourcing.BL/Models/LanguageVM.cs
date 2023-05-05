using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.ViewModels
{
    public class LanguageVM
    {
        public int Id { get; set; }

        public string LangName { get; set; }
        public string Level { get; set; }


        public int FreelancerId { get; set; }
        //public Freelancer Freelancer { get; set; }

    }
}
