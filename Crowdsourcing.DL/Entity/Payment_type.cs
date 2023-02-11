using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Payment_type
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public ICollection<Service> Service { get; set; }

    }
}
