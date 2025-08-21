using System.Net;
using System.Text.Json;
using Library;
using Moq;
using Moq.Protected;

namespace Library.Tests;

/// <summary>
/// Tests for WeatherService demonstrating mocking external dependencies.
/// Shows how to test async methods and HTTP client interactions.
/// </summary>
public class WeatherServiceTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly WeatherService _weatherService;
    private const string TestApiKey = "test-api-key";

    public WeatherServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _weatherService = new WeatherService(_httpClient, TestApiKey);
    }

    [Fact]
    public void Constructor_WithNullHttpClient_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new WeatherService(null!, TestApiKey));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_WithInvalidApiKey_ThrowsArgumentException(string apiKey)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new WeatherService(_httpClient, apiKey));
    }

    [Fact]
    public void Constructor_WithZeroMaxRetries_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new WeatherService(_httpClient, TestApiKey, 0));
    }

    [Fact]
    public async Task GetCurrentWeatherAsync_WithValidCity_ReturnsWeatherInfo()
    {
        // Arrange
        var city = "London";
        var expectedResponse = new
        {
            Temperature = 20.5,
            Humidity = 65,
            Description = "Partly cloudy"
        };
        var responseJson = JsonSerializer.Serialize(expectedResponse);
        
        SetupHttpResponse(HttpStatusCode.OK, responseJson);

        // Act
        var result = await _weatherService.GetCurrentWeatherAsync(city);

        // Assert
        Assert.Equal(city, result.City);
        Assert.Equal(20.5, result.Temperature);
        Assert.Equal(65, result.Humidity);
        Assert.Equal("Partly cloudy", result.Description);
        Assert.True(result.Timestamp <= DateTime.UtcNow);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task GetCurrentWeatherAsync_WithInvalidCity_ThrowsArgumentException(string city)
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _weatherService.GetCurrentWeatherAsync(city));
    }

    [Fact]
    public async Task GetCurrentWeatherAsync_WhenCityNotFound_ThrowsWeatherServiceException()
    {
        // Arrange
        SetupHttpResponse(HttpStatusCode.NotFound, "");

        // Act & Assert
        var exception = await Assert.ThrowsAsync<WeatherServiceException>(
            () => _weatherService.GetCurrentWeatherAsync("NonexistentCity"));
        
        Assert.Contains("not found", exception.Message);
    }

    [Fact]
    public async Task GetCurrentWeatherAsync_WhenServiceUnavailable_RetriesAndThrows()
    {
        // Arrange
        SetupHttpResponse(HttpStatusCode.InternalServerError, "");

        // Act & Assert
        var exception = await Assert.ThrowsAsync<WeatherServiceException>(
            () => _weatherService.GetCurrentWeatherAsync("London"));
        
        Assert.Contains("unavailable after", exception.Message);
        
        // Verify retry attempts (should be called 3 times by default)
        _httpMessageHandlerMock.Protected()
            .Verify("SendAsync", Times.Exactly(3), 
                ItExpr.IsAny<HttpRequestMessage>(), 
                ItExpr.IsAny<CancellationToken>());
    }

    [Fact]
    public async Task GetForecastAsync_WithValidParameters_ReturnsForecast()
    {
        // Arrange
        var city = "Paris";
        var days = 3;
        var expectedResponse = new
        {
            Days = new[]
            {
                new { Date = DateTime.Today, HighTemp = 25.0, LowTemp = 15.0, Description = "Sunny" },
                new { Date = DateTime.Today.AddDays(1), HighTemp = 22.0, LowTemp = 12.0, Description = "Cloudy" },
                new { Date = DateTime.Today.AddDays(2), HighTemp = 20.0, LowTemp = 10.0, Description = "Rainy" }
            }
        };
        var responseJson = JsonSerializer.Serialize(expectedResponse);
        
        SetupHttpResponse(HttpStatusCode.OK, responseJson);

        // Act
        var result = await _weatherService.GetForecastAsync(city, days);

        // Assert
        Assert.Equal(city, result.City);
        Assert.Equal(3, result.Days.Count);
        Assert.Equal("Sunny", result.Days[0].Description);
        Assert.Equal(25.0, result.Days[0].HighTemp);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(8)]
    [InlineData(-1)]
    public async Task GetForecastAsync_WithInvalidDays_ThrowsArgumentException(int days)
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _weatherService.GetForecastAsync("London", days));
    }

    [Fact]
    public async Task IsServiceAvailableAsync_WhenServiceResponds_ReturnsTrue()
    {
        // Arrange
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri!.ToString().Contains("health")),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        // Act
        var result = await _weatherService.IsServiceAvailableAsync();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task IsServiceAvailableAsync_WhenServiceThrows_ReturnsFalse()
    {
        // Arrange
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(req => req.RequestUri!.ToString().Contains("health")),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Network error"));

        // Act
        var result = await _weatherService.IsServiceAvailableAsync();

        // Assert
        Assert.False(result);
    }

    private void SetupHttpResponse(HttpStatusCode statusCode, string content)
    {
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(content)
            });
    }

    // TODO: Students can add more advanced tests:
    // - Test network timeout scenarios
    // - Test malformed JSON responses
    // - Test rate limiting (429 status code)
    // - Test authentication errors (401 status code)
    // - Test concurrent requests
    // - Test cancellation token handling
    // - Verify exact HTTP request URLs and headers
    // - Test retry logic with exponential backoff timing
}
