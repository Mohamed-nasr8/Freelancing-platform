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
    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]

        public int  RatingValue { get; set; }

        public int Comment { get; set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }


        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }





    }
}
