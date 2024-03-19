using Microsoft.AspNetCore.Identity;
using Sales.Shared.Entites;

namespace Sales.API.Helpers
{
    //Interfaz de manejo de usuarios
    public interface IUserHelper
    {

        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

    }
}
