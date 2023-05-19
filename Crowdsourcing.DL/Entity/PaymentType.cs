using System.ComponentModel.DataAnnotations;

namespace Crowdsourcing.DL.Entity
{
    public class PaymentType
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }


        public ICollection<Proposal> Proposals { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Withdraw> Withdraws { get; set; }


    }
}
