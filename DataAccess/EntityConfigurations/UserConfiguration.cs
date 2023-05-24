using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(p => p.Email).HasColumnName("Email").IsRequired();
        builder.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(p => p.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(p => p.Email, "UK_Users_Email").IsUnique();
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        builder.HasMany(p => p.UserOperationClaims);
        builder.HasData(getSeeds());
    }

    private HashSet<User> getSeeds()
    {
        HashingHelper.CreatePasswordHash("1234", out byte[] passwordHash, out byte[] passwordSalt);
        int id = 0;
        HashSet<User> seeds =
            new()
            {
                new()
                {
                    Id = ++id,
                    FirstName = "Furkan",
                    LastName = "Yazar",
                    Email = "contact@furkanyazar.dev",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            };
        return seeds;
    }
}
