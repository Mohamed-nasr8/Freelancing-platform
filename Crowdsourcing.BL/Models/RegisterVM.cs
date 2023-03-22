using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class RegisterVM
    {


        [Required(ErrorMessage = "First name is required.")]
        [StringLength(128, ErrorMessage = "First name cannot be longer than 128 characters.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(128, ErrorMessage = "Last name cannot be longer than 128 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(17, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 17 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
