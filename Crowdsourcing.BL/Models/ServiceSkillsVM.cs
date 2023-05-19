﻿using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class ServiceSkillsVM
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }


        //public int ServiceId { get; set; }
 
    }
}