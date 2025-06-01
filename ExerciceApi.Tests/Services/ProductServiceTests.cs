using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciceApi.Models;
using ExerciceApi.Repositories.Interface;
using ExerciceApi.Services.Implementation;
using ExerciceApi.Services.Interface;
using Moq;
using Xunit;

namespace ExerciceApi.Tests.Services
{
    public class ProductServiceTests
    {
        private (ProductService service, Mock<IProductRepository> repo) CreateService()
        {
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);
            return (service, mockRepo);
        }

        [Fact]
        public async Task RegisterProduct_ShouldReturnValidProduct_WhenGivenValidRequest()
        {
            //Arrange
            var (service, _) = CreateService();

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
            var result = await service.RegisterProduct(request);

            //Assert
            Assert.NotNull(result.Id);
            Assert.Equal("Test Product 1", result.Description);
            Assert.Equal(29.99f, result.Price);
            Assert.Single(result.Categories);
        }

        [Fact]
        public void RegisterProduct_ShouldThrowException_WhenPriceIsInvalid()
        {
            //Arrange
            var (service, _) = CreateService();
            var request = new RegisterProductRequest
            {
                Description = "Invalid Price",
                Price = "Price",
                Categories = new List<CategoryDTO>(),
            };

            //Act & Assert
            Assert.ThrowsAsync<FormatException>(async () => await service.RegisterProduct(request));
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenExists()
        {
            //Arrange
            var guid = Guid.NewGuid().ToString();
            var product = new Product
            {
                Id = guid,
                Description = "Product 1",
                Price = 29.99f,
                Categories = new List<string> { "Category1" }
            };

            var (service, repo) = CreateService();
            repo.Setup(r => r.GetProductByIdAsync(guid)).ReturnsAsync(product);

            //Act
            var result = await service.GetProductByIdAsync(guid);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guid, result.Id);
        }
    }
}