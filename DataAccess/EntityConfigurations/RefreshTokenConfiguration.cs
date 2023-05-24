using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(p => p.Token).HasColumnName("Token").IsRequired();
        builder.Property(p => p.Expires).HasColumnName("Expires").IsRequired();
        builder.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(p => p.Revoked).HasColumnName("Revoked");
        builder.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        builder.HasOne(p => p.User);
    }
}
