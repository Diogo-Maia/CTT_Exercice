using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciceApi.Models;
using ExerciceApi.Repositories.Interface;

namespace ExerciceApi.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}