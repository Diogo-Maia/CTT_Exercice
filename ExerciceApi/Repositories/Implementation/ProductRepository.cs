using MongoDB.Driver;
using ExerciceApi.Models;
using ExerciceApi.Repositories.Interface;

namespace ExerciceApi.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        public ProductRepository(IMongoClient client)
        {
            var database = client.GetDatabase("ProductDB");
            _collection = database.GetCollection<Product>("Products");
        }
        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(Product product)
        {
            await _collection.InsertOneAsync(product);
        }
    }
}