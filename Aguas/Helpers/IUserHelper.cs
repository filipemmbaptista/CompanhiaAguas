using Aguas.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Aguas.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
