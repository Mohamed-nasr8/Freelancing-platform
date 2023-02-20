using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class RatingVM
    {

        public int Id { get; set; }

        [Range(1, 5)]
        [Required(ErrorMessage = "Please provide a rating from 1 to 5.")]
        public int RatingValue { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment must be between 5 and 500 characters.")]
        public string Comment { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int FreelancerId { get; set; }
        public string FreelancerName { get; set; }

    }
}
