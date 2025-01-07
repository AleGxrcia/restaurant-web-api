using Microsoft.AspNetCore.Identity;
using RestaurantWebApi.Core.Application.Enums;
using RestaurantWebApi.Infrastructure.Identity.Entities;

namespace RestaurantWebApi.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Waiter.ToString()));
        }
    }
}
