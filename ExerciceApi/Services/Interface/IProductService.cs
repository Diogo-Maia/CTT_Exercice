using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciceApi.Models;

namespace ExerciceApi.Services.Interface
{
    public interface IProductService
    {
        Task<Product> RegisterProduct(RegisterProductRequest request);
        Task<Product?> GetProductByIdAsync(string id); 
    }
}