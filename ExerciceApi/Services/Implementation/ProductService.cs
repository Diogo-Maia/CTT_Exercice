using ExerciceApi.Models;
using ExerciceApi.Repositories.Interface;
using ExerciceApi.Services.Interface;

namespace ExerciceApi.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<Product?> GetProductByIdAsync(string id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public Product RegisterProduct(RegisterProductRequest request)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Description = request.Description,
                Price = float.Parse(request.Price),
                Categories = request.Categories.Select(cat => cat.Id).ToList(),
                Stock = 0
            };

            _productRepository.SaveAsync(product);

            return product;
        }
    }
}