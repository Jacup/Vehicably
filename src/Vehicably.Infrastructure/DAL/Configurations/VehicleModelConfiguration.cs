using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicably.Domain.Models.Vehicles;

namespace Vehicably.Infrastructure.DAL.Configurations;

public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.HasKey(vm => vm.Id);

        builder.Property(vm => vm.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.ToTable("VehicleModels");
    }
}
