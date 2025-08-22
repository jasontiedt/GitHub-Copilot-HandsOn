using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text.Json;
using WeatherApi.Models;
using WeatherApi.Services;
using Xunit;

namespace WeatherApi.Tests;

public class WeatherControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public WeatherControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetForecast_ReturnsSuccessAndCorrectContentType()
    {
        // Act
        var response = await _client.GetAsync("/api/weather/forecast");

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }

    [Fact]
    public async Task GetForecast_ReturnsExpectedNumberOfDays()
    {
        // Act
        var response = await _client.GetAsync("/api/weather/forecast");
        var content = await response.Content.ReadAsStringAsync();
        var forecast = JsonSerializer.Deserialize<WeatherForecast[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });

        // Assert
        Assert.NotNull(forecast);
        Assert.Equal(5, forecast.Length);
    }

    [Theory]
    [InlineData("Seattle")]
    [InlineData("Portland")]
    [InlineData("san francisco")] // Test case insensitive
    public async Task GetCurrentWeather_ValidCity_ReturnsSuccess(string city)
    {
        // Act
        var response = await _client.GetAsync($"/api/weather/current/{city}");

        // Assert
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var weather = JsonSerializer.Deserialize<WeatherData>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });
        
        Assert.NotNull(weather);
        Assert.Equal(city, weather.City, ignoreCase: true);
    }

    [Fact]
    public async Task GetCurrentWeather_InvalidCity_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/weather/current/InvalidCity");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetCurrentWeather_EmptyCity_ReturnsBadRequest()
    {
        // Act
        var response = await _client.GetAsync("/api/weather/current/");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode); // 404 because route doesn't match
    }

    [Fact]
    public async Task GetHistoricalWeather_ValidParameters_ReturnsSuccess()
    {
        // Arrange
        var city = "Seattle";
        var startDate = DateTime.Today.AddDays(-7);
        var endDate = DateTime.Today.AddDays(-1);

        // Act
        var response = await _client.GetAsync(
            $"/api/weather/history/{city}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");

        // Assert
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var historicalData = JsonSerializer.Deserialize<WeatherData[]>(content, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true 
        });
        
        Assert.NotNull(historicalData);
        Assert.Equal(7, historicalData.Length); // 7 days of data
    }

    [Fact]
    public async Task GetHistoricalWeather_FutureDate_ReturnsBadRequest()
    {
        // Arrange
        var city = "Seattle";
        var startDate = DateTime.Today.AddDays(1);
        var endDate = DateTime.Today.AddDays(2);

        // Act
        var response = await _client.GetAsync(
            $"/api/weather/history/{city}?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task HealthCheck_ReturnsHealthy()
    {
        // Act
        var response = await _client.GetAsync("/health");

        // Assert
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Healthy", content);
    }
}
