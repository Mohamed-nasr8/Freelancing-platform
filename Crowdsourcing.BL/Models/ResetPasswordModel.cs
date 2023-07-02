using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
	public class ResetPasswordModel
	{
		[Required(ErrorMessage ="Username is required")] 
		public string UserName { get; set; }

		[Required(ErrorMessage = "New Password is required")]
		public string NewPassword { get; set; }
		[Required(ErrorMessage = "Confirm New Password is required")]
		public string ConfirmNewPassword { get; set; }

		public string Token { get; set; }

	}
}
