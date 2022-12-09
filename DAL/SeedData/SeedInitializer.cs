using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.SeedData
{
    public class SeedInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "lev.myshkin@outlook.com";
            string password = "Myshkin0101";
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

        public static void ContextSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType()
                {
                    Id = 1, Name = "Computers & Tablets"
                },
                new ProductType()
                {
                    Id = 2, Name = "Game Consoles"
                }
            );

            modelBuilder.Entity<ProductBrand>().HasData(
                new ProductBrand()
                {
                    Id = 1, Name = "ASUS"
                },
                new ProductBrand()
                {
                    Id = 2, Name = "Lenovo"
                },
                new ProductBrand()
                {
                    Id = 3, Name = "Microsoft Xbox"
                },
                new ProductBrand()
                {
                    Id = 4, Name = "Sony PlayStation"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1, Name = "ASUS ROG Strix G35CZ Gaming Desktop PC",
                    Description =
                        "ASUS ROG Strix G35CZ Gaming Desktop PC, GeForce RTX 2080 SUPER, Factory Overclocked Intel Core i9-10900KF, 32GB DDR4 RAM, 1TB PCIe SSD, Dual Hot-Swap SSD Bays, Windows 10 Professional, G35CZ-XB982",
                    Price = new decimal(6500.00), PictureUrl = "images/products/pc1.jpg", ProductBrandId = 1,
                    ProductTypeId = 1
                },
                new Product()
                {
                    Id = 2, Name = "Lenovo Legion 5 Desktop PC Computer",
                    Description =
                        "Lenovo Legion 5 Desktop PC Computer | 10th Gen Intel Core i7-10700 | 16GB RAM | 512GBSSD +2TBHDD | NVIDIA GeForce RTX 2060 | Wi-Fi 6 | HDMI | Keyboard and Mouse | Windows 10",
                    Price = new decimal(2500.00), PictureUrl = "images/products/pc2.jpg", ProductBrandId = 2,
                    ProductTypeId = 1
                },
                new Product()
                {
                    Id = 3, Name = "Xbox Series S",
                    Description =
                        "Make the most of every gaming minute with Quick Resume, lightning-fast load times, and gameplay of up to 120 FPS—all powered by Xbox Velocity Architecture.",
                    Price = new decimal(350.00), PictureUrl = "images/products/console1.jpg", ProductBrandId = 3,
                    ProductTypeId = 2
                },
                new Product()
                {
                    Id = 4, Name = "PlayStation 5 Console",
                    Description =
                        "Lightning Speed - Harness the power of a custom CPU, GPU, and SSD with Integrated I/O that rewrite the rules of what a PlayStation console can do",
                    Price = new decimal(400.00), PictureUrl = "images/products/console2.jpg", ProductBrandId = 4,
                    ProductTypeId = 2
                }
            );
        }
    }
}