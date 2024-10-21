using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicably.Domain.Models.Vehicles.VehicleData;

namespace Vehicably.Infrastructure.DAL.Configurations;

public class VehicleModelConfiguration : BaseEntityConfiguration<VehicleModel>
{
    public override void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        base.Configure(builder);

        builder.Property(vm => vm.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.ToTable("VehicleModels");
    }
}
