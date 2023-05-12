﻿using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService , IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
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