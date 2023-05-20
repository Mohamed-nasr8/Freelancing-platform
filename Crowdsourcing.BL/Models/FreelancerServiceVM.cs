using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class FreelancerServiceVM
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public SkillLevel Level { get; set; }


        public int FreelancerId { get; set; }

    }

}

