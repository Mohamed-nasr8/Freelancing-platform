using System.ComponentModel.DataAnnotations;

namespace Crowdsourcing.BL.Models
{
    public class RoleVM
    {
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public string Role { get; set; }


    }
}
