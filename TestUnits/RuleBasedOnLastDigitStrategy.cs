using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Services;
using Xunit;

namespace TestUnits
{

    public class ExternalImageServiceTests
    {
        [Fact]
        public async Task GetImageUrlFromApiAsync_ShouldReturnUrl_WhenApiCallSucceeds()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"id\":6,\"url\":\"https://example.com/image6.png\"}")
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new ExternalImageService(httpClient);

            // Act
            var result = await service.GetImageUrlFromApiAsync(6);

            // Assert
            Assert.Equal("https://example.com/image6.png", result);
        }

        [Fact]
        public async Task GetImageUrlFromApiAsync_ShouldReturnNull_WhenApiCallFails()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new ExternalImageService(httpClient);

            // Act
            var result = await service.GetImageUrlFromApiAsync(6);

            // Assert
            Assert.Null(result);
        }
    }

}
