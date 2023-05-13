using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class OtherSkills
    {


        public int Id { get; set; }

        //public int SkillId { get; set; }
        //public Skill Skill { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
