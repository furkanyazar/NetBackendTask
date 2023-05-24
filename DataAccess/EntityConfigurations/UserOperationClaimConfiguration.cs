using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder
            .HasIndex(p => new { p.UserId, p.OperationClaimId }, "UK_UserOperationClaims_UserId_OperationClaimId")
            .IsUnique();
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        builder.HasOne(p => p.User);
        builder.HasOne(p => p.OperationClaim);
        builder.HasData(getSeeds());
    }

    private HashSet<UserOperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<UserOperationClaim> seeds =
            new()
            {
                new()
                {
                    Id = ++id,
                    UserId = 1,
                    OperationClaimId = 1
                }
            };
        return seeds;
    }
}
