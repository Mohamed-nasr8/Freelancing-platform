using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.ViewModels
{
    public class EducationVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your school")]
        [MaxLength(150)]
        public string School { get; set; }

        [Required(ErrorMessage = "Please enter your degree")]
        [MaxLength(150)]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Please enter your field of study")]
        [MaxLength(200)]
        public string FeldOfStudy { get; set; }

        [Required(ErrorMessage = "Please enter Date attended")]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Please enter Date attended")]
        public DateTime DateTo { get; set; }

        [Required(ErrorMessage = "Please describe your study")]
        [MinLength(20)]
        public string Description { get; set; }

        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
    }
}
