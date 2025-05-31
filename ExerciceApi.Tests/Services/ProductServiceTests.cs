using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciceApi.Models;
using ExerciceApi.Services.Implementation;
using Xunit;

namespace ExerciceApi.Tests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void RegisterProduct_ShouldReturnValidProduct_WhenGivenValidRequest()
        {
            //Arrange
            var service = new ProductService();
            var request = new RegisterProductRequest
            {
                Description = "Test Product 1",
                Price = "29.99",
                Categories = new List<CategoryDTO>
                {
                    new CategoryDTO {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Books"
                    }
                }
            };

            //Act
            var result = service.RegisterProduct(request);

            //Assert
            Assert.NotNull(result.Id);
            Assert.Equal("Test Product 1", result.Description);
            Assert.Equal(29.99f, result.Price);
            Assert.Single(result.Categories);
        }
    }
}