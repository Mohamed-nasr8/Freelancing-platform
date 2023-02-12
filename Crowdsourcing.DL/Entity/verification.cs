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
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string first_name_Ar { get; set; }

        [Required]
        [MaxLength(50)]
        public string last_name_Ar { get; set; }

        [Required]
        [MaxLength(20)]
        public string country { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime date_of_birth { get; set; }

        [Required]
        public string front_image { get; set; }

        [Required]
        public string back_image { get; set; }

        [Required]
        public string personal_photo { get; set; }

        public Service Service { get; set; }





    }
}
