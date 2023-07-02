﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Models
{
	public class ChangePasswordModel
	{
		[Required(ErrorMessage ="username is Required")]
		public string Username { get; set; }

		[Required(ErrorMessage ="Current Password is required")]
		public string CurrentPassword { get; set; }

		[Required(ErrorMessage = "New Password is required")]
		public string NewPassword { get; set; }

		[Required(ErrorMessage = "Confirm New Password is required")]
		public string ConfirmNewPassword { get; set; }

	}
}
