using System.Collections.Generic;
using EShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DataAccess.Mappings.EF
{
    public class UserGroupMap:IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable("UserGroups");
            builder.HasIndex(x => x.Description);
            
            builder.HasData(new List<UserGroup>
            {
                new()
                {
                    Id = 1,
                    Description = "Admin"
                },
                new()
                {
                Id = 2,
                Description = "Son Kullanıcı"
            },
            });
        }
    }
}