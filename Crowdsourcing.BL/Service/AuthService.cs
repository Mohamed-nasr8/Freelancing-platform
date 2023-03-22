﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPIJWT.Models;
using Microsoft.Extensions.Options;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.BL.Models;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Helper;

namespace TestAPIJWT.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public AuthService(UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager , IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }


        public async Task<AuthModel> RegisterAsync(RegisterVM model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "Email Is Alredy Signed" };

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                return new AuthModel { Message = "Username Is Alredy Signed" };

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FName,
                LastName = model.LName
            };

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded) {
            
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}  - ";
                }

                return new AuthModel { Message=errors};
            }

            await _userManager.AddToRoleAsync(user, "User");

            var jwtSecurityToken =  await CreateJwtToken(user);

            return new AuthModel
            {
                Email = user.Email,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Username = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
        }


        public async Task<AuthModel> loginAsync(loginVM model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);
            if( user is null || await _userManager.CheckPasswordAsync(user,model.Password) )
            {
                authModel.Message = "Email or Password is incorrect";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var roleList = await _userManager.GetRolesAsync(user);

            authModel.Username= user.UserName;
            authModel.IsAuthenticated = true;
            authModel.Email = user.Email;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = roleList.ToList();
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);


            return authModel;
        }

        public async Task<string> AddRoleAsync(RoleVM model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid User id Or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User Already Assigned To Role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something Went Wrong";
        }


        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
