using EShop.Core.Helper;
using EShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DataAccess.Mappings.EF
{
    public class AccountMap:IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => new{x.FirstName, x.LastName});
            builder.HasIndex(x => x.Gsm);
            
            HashingHelper.CreatePasswordHash("1234",out var passwordHash,out var passwordSalt);
            builder.HasData(new Account
            {
                Id = 1,
                FirstName = "Abdi",
                LastName = "KURT",
                Email = "abdikurt@gmail.com",
                Gsm = "5423269293",
                IsSuperVisor = true,
                UserGroupId = 2,
                GenderId = 2,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedUser = "Migration"
            });
        }
    }
}