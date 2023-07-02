using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Message
    {
        public int Id { get; set; }

        public int FreelancerId { get; set; } // Foreign key for Freelancer entity
        public Freelancer Freelancer { get; set; } // Navigation property to access the Freelancer entity

        public int ClientId { get; set; } // Foreign key for Client entity
        public Client Client { get; set; } // Navigation property to access the Client entity
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}
