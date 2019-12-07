using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public static class SeedDataIdentity
    {
        private const string generalUserName1 = "Nazia";
        private const string generalUserPass1 = "Password1@";

        private const string generalUserName2 = "Thales";
        private const string generalUserPass2 = "Password12@";

        private const string generalUserName3 = "Goedy";
        private const string generalUserPass3 = "Password123@";

        private const string Role1 = "General";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();
            context.Database.Migrate();

            RoleManager<IdentityRole> role = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();
            await role.CreateAsync(new IdentityRole(Role1));

            UserManager<IdentityUser> userManager = app.ApplicationServices
          .GetRequiredService<UserManager<IdentityUser>>();

            //create first user
            IdentityUser user1 = await userManager.FindByIdAsync(generalUserName1);
            if (user1 == null)
            {
                user1 = new IdentityUser(generalUserName1);
                await userManager.CreateAsync(user1, (generalUserPass1));
                await userManager.AddToRoleAsync(user1, Role1);
            }
            //create 2nd user
            IdentityUser user2 = await userManager.FindByIdAsync(generalUserName2);
            if (user2 == null)
            {
                user2 = new IdentityUser(generalUserName2);
                await userManager.CreateAsync(user2, (generalUserPass2));
                await userManager.AddToRoleAsync(user2, Role1);
            }
            //create 3rd user
            IdentityUser user3 = await userManager.FindByIdAsync(generalUserName3);
            if (user3 == null)
            {
                user3 = new IdentityUser(generalUserName3);
                await userManager.CreateAsync(user3, (generalUserPass3));
                await userManager.AddToRoleAsync(user3, Role1);
            }
        }
    }
}
