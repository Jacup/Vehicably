using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicably.Domain.Models.Vehicles.VehicleData;

namespace Vehicably.Infrastructure.DAL.Configurations;

public class VehicleBrandConfiguration : BaseEntityConfiguration<VehicleBrand>
{
    public override void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        base.Configure(builder);

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
