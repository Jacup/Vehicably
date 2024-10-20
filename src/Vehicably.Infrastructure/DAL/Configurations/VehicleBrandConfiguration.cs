using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicably.Domain.Models.Vehicles;

namespace Vehicably.Infrastructure.DAL.Configurations;

public class VehicleBrandConfiguration : IEntityTypeConfiguration<VehicleBrand>
{
    public void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        builder.HasKey(vb => vb.Id);

        builder.Property(vb => vb.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder
            .HasMany(vb => vb.Models)
            .WithOne(vm => vm.Brand)
            .HasForeignKey(vm => vm.BrandId)
            .IsRequired();

        builder.ToTable("VehicleBrands");
    }
}
