using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShopProjectWebAPI.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<User> FindUserByClaimsPrincipleWithAddress(this UserManager<User> userManager, 
            ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await userManager.Users.Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<User> FindByEmailFromClaimsPrincipal(this UserManager<User> userManager, 
            ClaimsPrincipal user)
        {
            return await userManager.Users
                .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
        }
    }
}