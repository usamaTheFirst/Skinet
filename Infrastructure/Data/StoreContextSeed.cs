using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                context.ProductBrands.AddRange(brands);

            }
            if (!context.ProductTypes.Any())
            {
                var TypeData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);
                context.ProductTypes.AddRange(types);

            }
            if (!context.Products.Any())
            {
                var productData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.Products.AddRange(products);

            }
            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
