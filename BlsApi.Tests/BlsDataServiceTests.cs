using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

using CPIService.Core;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace BlsApi.Tests;

public class BlsDataServiceTests
{
    [Fact]
    public async Task GetBlsDataAsync_ReturnsData_WhenNotCached()
    {
        // Arrange
        var mockFactory = new Mock<IHttpClientFactory>();
        var mockHandler = new HttpMessageHandlerStub();
        var client = new HttpClient(mockHandler);
        mockFactory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(client);

        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        var service = new BlsDataService(memoryCache, mockFactory.Object);

        string testSeriesId = "LAUCN040010000000005";

        // Act
        var result = await service.GetBlsDataAsync(testSeriesId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("LAUCN040010000000005", result.Results.Series[0].SeriesID);
    }

}

