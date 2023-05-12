using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crowdsourcing.DL.Entity
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public string Status { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime created_at { get; set; } // defult value using flunet Api


        public int ClientId { get; set; }
        public Client Client { get; set; }


        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }









    }
}
