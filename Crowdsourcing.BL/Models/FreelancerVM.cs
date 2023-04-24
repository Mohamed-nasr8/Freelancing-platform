using Crowdsourcing.DL.Entity;
using Crowdsourcing.DL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.ViewModels
{
    public class FreelancerVM
    {

        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public string Overview { get; set; }
    

        public IFormFile Cv { get; set; }

        public IFormFile Photo { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage ="Pleasr enter your title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your bio")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Please ter your hourly rate ")]
        [Range(1, 50)]
        public decimal HourlyRate { get; set; }

        public float? Rating { get; set; }

        [Required(ErrorMessage = "Please enter your contry")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your street")]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your Phone ")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        public int? Point { get; set; }
 

        //public ICollection<Notification> Notifications { get; set; }
        //public ICollection<Rating> Ratings { get; set; }
        //public ICollection<Language> Languages { get; set; }
        //public ICollection<Withdraw> Withdraws { get; set; }
        //public ICollection<HasSkill> HasSkills { get; set; }
        //public ICollection<HasFreelancerService> HasFreelancerServices { get; set; }
        //public ICollection<Expereince> Expereinces { get; set; }
        //public ICollection<Education> Educations { get; set; }
        //public ICollection<Proposal> Proposals { get; set; }
        //public ICollection<Message> Messages { get; set; }
    }
}
