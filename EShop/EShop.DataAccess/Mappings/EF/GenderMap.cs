using EShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DataAccess.Mappings.EF
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Genders");
            builder.HasIndex(x => x.Description);

            builder.HasData(new Gender
            {
                Id = 1,
                Description = "Kadın"
            });
            builder.HasData(new Gender
            {
                Id = 2,
                Description = "Erkek"
            });
        }
    }
}