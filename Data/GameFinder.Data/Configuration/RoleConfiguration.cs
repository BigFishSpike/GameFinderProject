using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFinder.Data.Configuration
{
    /*
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public static readonly IEnumerable<IdentityRole> InitialSeedRoles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = "gamemaster",
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new IdentityRole
            {
                Id = "gamer",
                Name = "User",
                NormalizedName = "USER",
            }
        };
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(InitialSeedRoles);

        }

    } */
}
