using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Verification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstNameAr { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastNameAr { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string FrontImage { get; set; }

        [Required]
        public string BackImage { get; set; }

        [Required]
        public string PersonalPhoto { get; set; }

        public Service Service { get; set; }

        public Freelancer Freelancer { get; set; }


    }
}
