using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Featurify.Core.Enums;
using System.Collections.Generic;

namespace Featurify.Infrastructure.Data.Configurations
{
    public partial class ApplicationRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> entity)
        {
            entity.HasKey(x => x.Id);

            var dataInit = new List<IdentityRole>()
            {
                IdentityRoleGenerate.CreateIntance(nameof(RoleEnum.Basic)),
                IdentityRoleGenerate.CreateIntance(nameof(RoleEnum.Admin))
            };

            entity.HasData(dataInit);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<IdentityRole> entity);
    }

    public static class IdentityRoleGenerate
    {
        public static IdentityRole CreateIntance(string role)
        {
            var roleInstance = new IdentityRole()
            {
                Name = role,
                NormalizedName = role.ToUpper()
            };

            return roleInstance;
        }
    }
}
