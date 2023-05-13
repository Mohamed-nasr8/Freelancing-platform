using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class FreelancerSkill
    {
        public int Id { get; set; }
        [MaxLength(128)]

        public string Name { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
