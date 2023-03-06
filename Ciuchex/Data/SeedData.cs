using Ciuchex.Data;
using Ciuchex.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ciuchex.Infrastucture
{
    public class SeedData
    {
        
        public static async void SeedDatabase(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            context.Database.Migrate();


            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("User"));
                await roleManager.CreateAsync(new IdentityRole("Manager"));
            }

            if (await userManager.FindByEmailAsync("admin@admin.com") == null)
            {
                IdentityUser adminUser = new()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    PhoneNumber = "123456789",
                    PhoneNumberConfirmed = true,
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");

            }

            if (!context.UserRoles.Any())
            {
                await userManager.AddToRoleAsync(userManager.FindByEmailAsync("admin@admin.com").Result, "Admin");
            }


            if (!context.Products.Any())
            {
                

                Category hoodies = new Category { Name = "Hoodies"};
                Category shirts = new Category { Name = "Shirts"};

                context.Products.AddRange(
                        new Product
                        {
                            Name = "Legend Zip Hoodie",
                            Description = "We continue exploring the college team culture with the new Legend Zip Hoodie offering a new handManufactured artwork featuring the brand logo in tonal varsity letters. The full zip hoodie comes with large front pockets and a drawstring hood. This hoodie has a relaxed, slightly oversized fit.",
                            Price = 195M,
                            Category = hoodies,
                            Image = "hoodie1.jpg"
                        },
                        new Product
                        {
                            Name = "Monogram Hoodie",
                            Description = "The Monogram Hoodie comes in a heavy weight organic cotton fabric detailed with a tonal name print on the front. The hoodie features a clean overlapping hood without strings and a classic pouch pocket at front.",
                            Price = 180M,
                            Category = hoodies,
                            Image = "hoodie2.jpg"
                        },
                        new Product
                        {
                            Name = "Catch Hoodie",
                            Description = "The Catch Hoodie presents a timeless silhouette detailed with a centered terry varsity “A” patch branding. The hoodie is Manufactured from 100% organic cotton featuring a drawstring hood and a pouch pocket.",
                            Price = 190M,
                            Category = hoodies,
                            Image = "hoodie3.jpg"
                        },
                        new Product
                        {
                            Name = "University Hoodie",
                            Description = "The University hoodie is Manufactured from organic cotton and embroidered at the chest with a contrasting logo and crest. It features drawstring ties at the hood and has a flexible ribbed hem and cuffs. This hoodie is cut in a regular fit.",
                            Price = 180M,
                            Category = hoodies,
                            Image = "hoodie4.jpg"
                        },
                        new Product
                        {
                            Name = "Signature T-Shirt",
                            Description = "The Signature T-shirt is cut from organic cotton in a classic crew-neck profile. It’s embroidered at the chest with a chain positioned to form our Signature A. This T-shirt is cut in an oversized fit.",
                            Price = 90M,
                            Category = shirts,
                            Image = "shirt1.jpg"
                        },
                        new Product
                        {
                            Name = "Monogram T-Shirt",
                            Description = "The Monogram T-Shirt is Manufactured out of 100% organic cotton and detailed with the signature name print on the chest. The minimalist design is available in multiple colorways.",
                            Price = 80M,
                            Category = shirts,
                            Image = "shirt2.jpg"
                        },
                        new Product
                        {
                            Name = "College T-Shirt",
                            Description = "The College T-shirt is cut from organic cotton in a classic crew-neck profile. It’s appliquéd at the chest with a terry ‘A’. This T-shirt is cut in a regular fit.",
                            Price = 90M,
                            Category = shirts,
                            Image = "shirt3.jpg"
                        },
                        new Product
                        {
                            Name = "Focus T-shirt",
                            Description = "The Focus T-Shirt, made from comfortable organic cotton, presents a relaxed silhouette. The short-sleeve offers a clean appearance with signature branding on the chest.",
                            Price = 80M,
                            Category = shirts,
                            Image = "shirt4.jpg"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}
