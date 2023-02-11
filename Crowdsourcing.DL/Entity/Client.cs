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
        public DateTime Registration_date { get; set; }
        [Required]

        public string Location { get; set; }

        public bool verifacation_state { get; set; }

        public int user_accountId { get; set; }

        public user_account user_account { get; set; }

        public ICollection<Notification> Notification { get; set; }

        public ICollection<Rating> Rating { get; set; }

        public ICollection<Service> Service { get; set; }






    }
}
