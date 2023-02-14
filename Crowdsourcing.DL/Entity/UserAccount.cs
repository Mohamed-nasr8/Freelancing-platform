using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Crowdsourcing.DL.Entity
{
    [Table("user_account")]
    public class UserAccount
    {
        public int Id { get; set; }

        [StringLength(128)]
        [Required]
        public string FName { get; set; }
        [StringLength(128)]
        [Required]
        public string LName { get; set; }
        [Required]
        [StringLength(17)]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [EmailAddress]
        [StringLength(128)]
        [DataType(DataType.EmailAddress)]

        [Required]  
        public string Email { get; set; }

        public ICollection<Client> Clients { get; set; }
        public ICollection<Freelancer> Freelanceres { get; set; }


    }
}
