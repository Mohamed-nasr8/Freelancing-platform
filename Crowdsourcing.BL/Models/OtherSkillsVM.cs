using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class OtherSkillsVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The SkillId field is required.")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        [Required(ErrorMessage = "The ServiceId field is required.")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
