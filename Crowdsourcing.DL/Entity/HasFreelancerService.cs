﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class HasFreelancerService
    {
        public int Id { get; set; }

        public int FreelancerServiceId { get; set; }
        public FreelancerService FreelancerService { get; set; }


        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}