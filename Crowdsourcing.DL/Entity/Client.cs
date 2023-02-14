using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Client
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Registrationdate { get; set; }
        [Required]

        public string Location { get; set; }

        public bool verifacationState { get; set; }

        public int UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Service> Services { get; set; }






    }
}
