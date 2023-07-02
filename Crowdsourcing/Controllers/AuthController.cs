using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.DL.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<ApplicationUser> _userManager;

		public AuthController(IAuthService authService , IHttpContextAccessor httpContextAccessor , UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
			_userManager = userManager;
		}


        #region register
        [HttpPost("register")]
        public async Task<IActionResult> RegiterAsync(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            return Ok(result);
        }
        #endregion


        #region Log In
        [HttpPost("login")]
        public async Task<IActionResult> loginAsync(loginVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.loginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            return Ok(result);
        }
		#endregion

		#region Change Password

		[HttpPost]
		[Route("change-password")]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model) { 

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null) { 
            return StatusCode(StatusCodes.Status404NotFound, new Response { Status= "Error", Message = "User does not exists!" });
            }
            if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0) {
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "The new password and confirm new password does not match!" });
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded) {
                var errors = new List<string>();
                foreach (var error in result.Errors) {

                    errors.Add(error.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = string.Join(", ", errors) });
            }   
                
                return Ok(new Response { Status = "Success", Message = "Password Changed Successfully!" });
        }


        #endregion

        #region Reset password Token

        [HttpPost]
		        [Route("reset-password-token")]
                public async Task<IActionResult> ResetPasswordToken([FromBody] PasswordTokenModel model) { 
                    var user = await _userManager.FindByNameAsync(model.Username);
                    if (user == null) { 
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "User does not exists!" });
                    }
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    //Best practice send token to user email and generate url, the following is for only example.q Techno Zone
                    return Ok(new { token = token });
                }

        #endregion


        #region Reset Password 


        [HttpPost]
		        [Route("reset-password")]
                public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
		        {
			        var user = await _userManager.FindByNameAsync(model.UserName);
			        if (user == null) { 
                    return StatusCode(StatusCodes.Status404NotFound, new Response { Status= "Error", Message = "User does not exists!" });
                    }
                    if (string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0) { 
	                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "The new password and confirm new password does not match!" });
                    }
                    if (string.IsNullOrEmpty(model.Token)) { 
	                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Invalid Token!" });
                    } 
            
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                    if (!result.Succeeded)
                    { 
                        var errors = new List<string>();
                        foreach (var error in result.Errors)
                        errors.Add(error.Description);
                        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = string.Join(", ", errors) });
                    }
                    return Ok(new Response { Status = "Success", Message = "Password Reseted Successfully!" });
                }


		        #endregion


		#region Add Role
		[HttpPost("addRole")]
        public async Task<IActionResult> AddRoleAsync(RoleVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);

        }
        #endregion


        #region Remove User From Role
        [HttpPost("removeUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string userId, string roleName)
        {
            var result = await _authService.RemoveUserFromRoleAsync(userId, roleName);

            if (result)
            {
                return Ok("User removed from role successfully.");
            }
            else
            {
                return BadRequest("Failed to remove user from role.");
            }
        }
        #endregion

    }
}
