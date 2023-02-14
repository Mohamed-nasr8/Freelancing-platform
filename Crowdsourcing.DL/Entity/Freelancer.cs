using Crowdsourcing.DL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Freelancer
    {
        
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public string Overview { get; set; }

        [Required]
        public string CVName { get; set; }

        [Required]
        public string ImageName { get; set; }

        [StringLength(150)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        [Range(1,50)]
        public decimal HourlyRate { get; set; }
 
        public float? Rating { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int? Point { get; set; }
        public bool VerficationState { get; set; }


        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }


        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Withdraw> Withdraws { get; set; }
        public ICollection<Verification> Verifications { get; set; }
        public ICollection<HasSkill> HasSkills { get; set; }
        public ICollection<HasFreelancerService> HasFreelancerServices { get; set; }
        public ICollection<Expereince> Expereinces { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<Message> Messages { get; set; }


        public int VerificationId { get; set; }
        public Verification Verification { get; set; }



    }
}