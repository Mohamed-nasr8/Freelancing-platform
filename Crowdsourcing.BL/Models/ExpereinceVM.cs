using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.ViewModels
{
    public class ExpereinceVM
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Company { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [MinLength(10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [MaxLength(100)]
        public string Region { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50)]
        public string Country { get; set; }

        public bool? WorkingInThisRole { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public string StartDate { get; set; }

        //[Required]
        public string? EndDate { get; set; }

        public int FreelancerId { get; set; }
        //public Freelancer Freelancer { get; set; }

    }
}
