using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;
using WebAPI.Repositories;
using WebAPI.Models;

namespace TestUnits
{
 

    public class DbImageRepositoryTests
    {
        private AppDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetImageUrlAsync_ShouldReturnCorrectUrl_WhenIdExists()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            context.Images.Add(new Image { Id = 1, Url = "https://example.com/1.png" });
            await context.SaveChangesAsync();

            var repository = new DbImageRepository(context);

            // Act
            string result = await repository.GetImageUrlAsync(1);

            // Assert
            result.Should().Be("https://example.com/1.png");
        }

        [Fact]
        public async Task GetImageUrlAsync_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            var repository = new DbImageRepository(context);

            // Act
            string result = await repository.GetImageUrlAsync(2);

            // Assert
            result.Should().BeNull();
        }
    }

}
