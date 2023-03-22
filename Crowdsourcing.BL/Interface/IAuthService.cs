using Crowdsourcing.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestAPIJWT.Models;

namespace Crowdsourcing.BL.Interface
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterVM model);
        Task<AuthModel> loginAsync(loginVM model);
        Task<string> AddRoleAsync(RoleVM model);
        Task<bool> RemoveUserFromRoleAsync(string userId, string roleName);

    }
}
