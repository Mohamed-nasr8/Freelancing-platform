using Microsoft.AspNetCore.Identity;

namespace Crowdsourcing.DL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string? RoleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Freelancer> Freelancers { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
