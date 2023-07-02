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
        public DateTime Registrationdate { get; set; } = DateTime.Now;
        [Required]



        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Message> Messages { get; set; }



    }
}
