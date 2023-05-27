using Core.Entities.Concrete;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.Value).HasColumnName("Value").IsRequired();
        builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(p => p.Name, "UK_OperationClaims_Name").IsUnique();
        builder.HasIndex(p => p.Value, "UK_OperationClaims_Value").IsUnique();
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        builder.HasMany(p => p.UserOperationClaims);
        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        const string adminName = "Admin";
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new()
                {
                    Id = ++id,
                    Name = adminName,
                    Value = adminName.ToValueCase()
                }
            };
        return seeds;
    }
}
