using Crowdsourcing.BL.Models;
using System.Threading.Tasks;
using TestAPIJWT.Models;

namespace Crowdsourcing.BL.Interface
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterVM model);
        Task<AuthModel> loginAsync(loginVM model);
        Task<string> AddRoleAsync(RoleVM model);

    }
}
