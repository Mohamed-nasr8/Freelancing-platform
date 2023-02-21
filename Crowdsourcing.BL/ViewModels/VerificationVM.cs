using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class VerificationVM
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter your first name in Arabic")]
        [MaxLength(50)]
        public string FirstNameAr { get; set; }

        [Required(ErrorMessage = "Please enter your last name in Arabic")]
        [MaxLength(50)]
        public string LastNameAr { get; set; }

        [Required(ErrorMessage = "Please select your country")]
        [MaxLength(20)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please upload a picture of the front side of your ID card or passport")]
        public string FrontImage { get; set; }

        [Required(ErrorMessage = "Please upload a picture of the back side of your ID card or passport")]
        public string BackImage { get; set; }

        [Required(ErrorMessage = "Please upload a personal photo of yourself")]
        public string PersonalPhoto { get; set; }

        public Service Service { get; set; }

        public int FreelancerId { get; set; }

        public Freelancer Freelancer { get; set; }
    }
}
