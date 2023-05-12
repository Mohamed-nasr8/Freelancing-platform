﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Withdraw
    {

        public int Id { get; set; }
        public string PaymentAmount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }


        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }



    }
}