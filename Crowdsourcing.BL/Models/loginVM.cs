using System.ComponentModel.DataAnnotations;

namespace Crowdsourcing.BL.Models
{
    public class loginVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
