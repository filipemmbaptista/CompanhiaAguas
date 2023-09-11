using Aguas.Data.Entities;
using Aguas.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aguas.Helpers
{
    public interface IUserHelper
    {
        #region UserManager
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<IdentityResult> AddUserNoPasswordAsync(User user);

        Task<IdentityResult> AddPasswordAsync(User user, string password);

        Task<List<User>> GetUsers();
        #endregion

        #region RoleManager
        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
        #endregion

        #region SignInManager
        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        #endregion
    }
}
