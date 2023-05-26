using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();
        builder.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.HasIndex(p => new { p.UserId, p.Name }, "UK_Products_UserId_Name").IsUnique();
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        builder.HasOne(p => p.User);
    }
}
