using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class FreelancerService
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public SkillLevel Level { get; set; }


        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

    }

    public enum SkillLevel
    {
        Entry = 1,
        Intermediate = 2,
        Expert = 3
    }
}
