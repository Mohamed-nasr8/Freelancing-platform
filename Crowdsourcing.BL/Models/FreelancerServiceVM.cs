using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class FreelancerServiceVM
    {
        public int Id { get; set; }

        [MaxLength(128, ErrorMessage = "Name cannot exceed 128 characters")]
        public string Name { get; set; }
        public int FreelancerId { get; set; }

    }
}
