using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class HasSkill
    {
        public int Id { get; set; }


        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}
