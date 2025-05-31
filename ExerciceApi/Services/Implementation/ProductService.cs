using ExerciceApi.Models;
using ExerciceApi.Services.Interface;

namespace ExerciceApi.Services.Implementation
{
    public class ProductService : IProductService
    {
        public Task<Product?> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Product RegisterProduct(RegisterProductRequest request)
        {
            return new Product
            {
                Id = Guid.NewGuid().ToString(),
                Description = request.Description,
                Price = float.Parse(request.Price),
                Categories = request.Categories.Select(cat => cat.Id).ToList(),
                Stock = 0
            };
        }
    }
}