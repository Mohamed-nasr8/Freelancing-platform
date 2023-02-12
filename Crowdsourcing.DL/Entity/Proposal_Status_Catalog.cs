using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Models
{
    public class Proposal_Status_Catalog
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }
        public ICollection<Message> Message { get; set; }
        public ICollection<Proposal> Proposal { get; set; }

    }
}
