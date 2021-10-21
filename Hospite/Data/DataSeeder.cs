using Hospite.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospite.Data
{
    public class DataSeeder
    {
       
        private const string adminPassword = "Admin@2021";
        private const string regularPassword = "Password@2021";

        public static async Task Seed(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HospiteDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();

            }

            if (context.Users.Any())
            {
                return;
            }
            else
            {



                //seed AppUser

                var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!userManager.Users.Any())
                {

                    var roles = new string[] { "Admin", "Customer" };
                    foreach (var role in roles)
                    {
                        var roleExist = await roleManager.RoleExistsAsync(role);
                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }


                    StreamReader userToRead = new StreamReader("../Hospite/Data/JsonFile/Data.json"); 
                    var userData = await userToRead.ReadToEndAsync();


                    // deserilization of Json object
                    var userInfo = JsonConvert.DeserializeObject<List<AppUser>>(userData);

                    var (adminCount, customerCount) = (0, 0);

                    foreach (var user in userInfo)
                    {
                        if (adminCount < 1)
                        {
                            await userManager.CreateAsync(user, adminPassword);
                            await userManager.AddToRoleAsync(user, roles[0]);
                            ++adminCount;
                        }
                        else
                        {
                            await userManager.CreateAsync(user, regularPassword);
                            await userManager.AddToRoleAsync(user, roles[1]);
                            ++customerCount;
                        }


                    }

                    await context.SaveChangesAsync();
                }
            }
        }



        
    }
}
