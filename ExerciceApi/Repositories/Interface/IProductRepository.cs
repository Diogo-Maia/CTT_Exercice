using ExerciceApi.Models;

namespace ExerciceApi.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(string id);
        Task SaveAsync(Product product);
    }
}