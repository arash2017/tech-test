using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using WebAPI.Repositories;

namespace TestUnits
{
   
    public class JsonImageRepositoryTests
    {
        [Fact]
        public async Task GetImageUrlAsync_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Arrange
            string jsonFilePath = "testDb.json";
            string json = "[{\"Id\":6,\"Url\":\"https://api.dicebear.com/8.x/pixel-art/png?seed=6&size=150\"}]";
            await File.WriteAllTextAsync(jsonFilePath, json);

            var repository = new JsonImageRepository(jsonFilePath);

            // Act
            string result = await repository.GetImageUrlAsync(2);

            // Assert
            result.Should().BeNull();

            // Cleanup
            File.Delete(jsonFilePath);
        }
        [Fact]
        public async Task GetImageUrlAsync_ShouldReturnCorrectUrl_WhenIdExists()
        {
            // Arrange
            string json = "[{\"Id\":6,\"Url\":\"https://api.dicebear.com/8.x/pixel-art/png?seed=6&size=150\"}]";  
            string filePath = "db12.json";
            await File.WriteAllTextAsync(filePath, json);

            var repository = new JsonImageRepository(filePath);

            // Act
            var result = await repository.GetImageUrlAsync(6);

            // Assert
            Assert.Equal("https://api.dicebear.com/8.x/pixel-art/png?seed=6&size=150", result);
        }

    }

}
