using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.SeedData
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "lev.myshkin@outlook.com";
            string password = "Pa$$W0rd1";
            if (await roleManager.FindByNameAsync("Administrator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Name = "LevMyshkin", Email = adminEmail, UserName = adminEmail, Address = new Address
                    {
                        FirstName = "Lev",
                        LastName = "Myshkin",
                        Street = "Bolshoy Prospekt 4",
                        City = "Saint Petersburg",
                        State = "Len. Obl.",
                        Zipcode = "190000"
                    }
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Administrator");
                }
            }
        }
    }
}