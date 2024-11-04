using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Vehicably.Domain.Entities.VehicleData;

namespace Vehicably.Infrastructure.DAL;

public static class ModelBuilderExtensions
{
    public static void SeedVehicleData(this ModelBuilder modelBuilder)
    {
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "Assets", "VehicleData.json");

        if (!File.Exists(jsonPath))
            throw new FileNotFoundException($"The file '{jsonPath}' was not found.", jsonPath);

        var jsonData = File.ReadAllText(jsonPath);
        using var document = JsonDocument.Parse(jsonData);
        var brands = document.RootElement.GetProperty("brands");

        foreach (var brand in brands.EnumerateArray())
        {
            var brandId = Guid.NewGuid();
            var brandName = brand.GetProperty("name").GetString();

            modelBuilder
                .Entity<VehicleBrand>()
                .HasData(new VehicleBrand
                {
                    Id = brandId,
                    Name = brandName!
                });

            foreach (var model in brand.GetProperty("models").EnumerateArray())
            {
                var modelId = Guid.NewGuid();
                var modelName = model.GetProperty("name").GetString();

                modelBuilder
                    .Entity<VehicleModel>()
                    .HasData(new VehicleModel
                    {
                        Id = modelId,
                        Name = modelName!,
                        BrandId = brandId
                    });
            }
        }
    }
}
