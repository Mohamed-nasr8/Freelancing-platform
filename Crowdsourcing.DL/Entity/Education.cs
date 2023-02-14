using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Education
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string School { get; set; }

        [Required]
        [MaxLength(150)]
        public string Degree { get; set; }

        [Required]
        [MaxLength(200)]
        public string FeildOfStudy { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

    }
}