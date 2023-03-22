using Crowdsourcing.DL.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crowdsourcing.DL.Models
{
    public class ProposalStatusCatalogVM
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(128)"),Required(ErrorMessage ="Requried Name")]
        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Proposal> Proposals { get; set; }

    }
}
