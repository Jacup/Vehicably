using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicably.Domain.Models;

namespace Vehicably.Infrastructure.DAL.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : DbObject
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedDate)
            .HasDefaultValueSql("NOW()");

        builder.Property(e => e.UpdatedDate)
            .HasDefaultValueSql("NOW()");
    }
}
