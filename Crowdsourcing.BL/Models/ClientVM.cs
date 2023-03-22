using Crowdsourcing.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
    public class ClientVM
    {

        public int Id { get; set; }
         public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Location is required.")]  
        public string Location { get; set; }

        public bool VerificationState { get; set; }

        [Display(Name = "User Account ID")]
        [Required(ErrorMessage = "User Account ID is required.")]
        public int UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
