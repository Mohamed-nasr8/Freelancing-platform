﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<OtherSkills> OtherSkills { get; set; }
        public ICollection<HasSkill> HasSkills { get; set; }


    }
}
