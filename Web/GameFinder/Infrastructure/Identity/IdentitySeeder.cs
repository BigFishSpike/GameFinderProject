namespace GameFinder.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using static GameFinder.Common.Constants.Roles;

    public static class IdentitySeeder
    {
        public static async Task SeedRolesAndAdminAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {

            string[] roles =
            {
                DefaultUser,
                Administrator
            };

            foreach (string role in roles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));

                    if (!result.Succeeded)
                    {
                        string errors = string.Join("; ", result.Errors.Select(e => e.Description));

                        throw new InvalidOperationException($"Failed to create the role '{role}'. Errors: {errors}");
                    }
                }
            }

            string? adminEmail = configuration["AdminSettings:Email"];

            if (string.IsNullOrWhiteSpace(adminEmail))
            {
                return;
            }

            IdentityUser? adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                return;
            }

            bool isAdmin = await userManager.IsInRoleAsync(adminUser, Administrator);

            if (!isAdmin)
            {
                IdentityResult result = await userManager.AddToRoleAsync(adminUser, Administrator);

                if (!result.Succeeded)
                {
                    string errors = string.Join("; ", result.Errors.Select(e => e.Description));

                    throw new InvalidOperationException($"Failed to assign the Administrator role. Errors: {errors}");
                }

            }
        }
    }
}