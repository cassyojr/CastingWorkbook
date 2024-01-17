using CastingWorkbook.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CastingWorkbook.Repository.Configuration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(x => x.Favorites).WithMany(x => x.Users);

        builder.HasData
        (
           new User
           {
               Id = 1,
               UserName = "cassyo",
               Password = "123"
           },
            new User
            {
                Id = 2,
                UserName = "john",
                Password = "321"
            },
            new User
            {
                Id = 3,
                UserName = "jeff",
                Password = "111"
            }
        );
    }
}
