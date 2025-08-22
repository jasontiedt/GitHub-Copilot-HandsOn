using WeatherApi.Services;
using WeatherApi.Models;
using Xunit;

namespace WeatherApi.Tests;

public class WeatherServiceTests
{
    private readonly WeatherService _weatherService;

    public WeatherServiceTests()
    {
        _weatherService = new WeatherService();
    }

    [Fact]
    public async Task GetForecastAsync_ReturnsCorrectNumberOfDays()
    {
        // Act
        var forecast = await _weatherService.GetForecastAsync();
        var forecastList = forecast.ToList();

        // Assert
        Assert.Equal(5, forecastList.Count);
    }

    [Fact]
    public async Task GetForecastAsync_ReturnsValidTemperatureRange()
    {
        // Act
        var forecast = await _weatherService.GetForecastAsync();

        // Assert
        Assert.All(forecast, f =>
        {
            Assert.InRange(f.TemperatureC, -20, 55);
            Assert.InRange(f.TemperatureF, -4, 131); // Converted range
        });
    }

    [Fact]
    public async Task GetForecastAsync_ReturnsValidHumidityRange()
    {
        // Act
        var forecast = await _weatherService.GetForecastAsync();

        // Assert
        Assert.All(forecast, f =>
        {
            Assert.InRange(f.Humidity, 30, 90);
        });
    }

    [Fact]
    public async Task GetForecastAsync_ReturnsValidWindSpeedRange()
    {
        // Act
        var forecast = await _weatherService.GetForecastAsync();

        // Assert
        Assert.All(forecast, f =>
        {
            Assert.InRange(f.WindSpeed, 0, 20);
        });
    }

    [Theory]
    [InlineData("Seattle")]
    [InlineData("Portland")]
    [InlineData("Chicago")]
    public async Task GetCurrentWeatherAsync_ValidCity_ReturnsWeatherData(string city)
    {
        // Act
        var weather = await _weatherService.GetCurrentWeatherAsync(city);

        // Assert
        Assert.NotNull(weather);
        Assert.Equal(city, weather.City);
        Assert.True(weather.DateTime <= DateTime.UtcNow);
        Assert.InRange(weather.Humidity, 30, 90);
        Assert.InRange(weather.WindDirection, 0, 359);
        Assert.InRange(weather.CloudCoverage, 0, 100);
    }

    [Fact]
    public async Task GetCurrentWeatherAsync_InvalidCity_ReturnsNull()
    {
        // Act
        var weather = await _weatherService.GetCurrentWeatherAsync("InvalidCity");

        // Assert
        Assert.Null(weather);
    }

    [Theory]
    [InlineData("SEATTLE")] // Test case insensitivity
    [InlineData("seattle")]
    [InlineData("Seattle")]
    public async Task GetCurrentWeatherAsync_CaseInsensitive_ReturnsWeatherData(string city)
    {
        // Act
        var weather = await _weatherService.GetCurrentWeatherAsync(city);

        // Assert
        Assert.NotNull(weather);
        Assert.Equal(city, weather.City);
    }

    [Fact]
    public async Task GetHistoricalWeatherAsync_ValidParameters_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        var city = "Seattle";
        var startDate = DateTime.Today.AddDays(-7);
        var endDate = DateTime.Today.AddDays(-3);
        var expectedDays = 5; // 7-3 = 4, but inclusive so 5 days

        // Act
        var historicalData = await _weatherService.GetHistoricalWeatherAsync(city, startDate, endDate);
        var dataList = historicalData.ToList();

        // Assert
        Assert.Equal(expectedDays, dataList.Count);
    }

    [Fact]
    public async Task GetHistoricalWeatherAsync_ValidParameters_ReturnsCorrectDates()
    {
        // Arrange
        var city = "Seattle";
        var startDate = DateTime.Today.AddDays(-5);
        var endDate = DateTime.Today.AddDays(-3);

        // Act
        var historicalData = await _weatherService.GetHistoricalWeatherAsync(city, startDate, endDate);
        var dataList = historicalData.ToList();

        // Assert
        Assert.Equal(startDate.Date, dataList.First().DateTime.Date);
        Assert.Equal(endDate.Date, dataList.Last().DateTime.Date);
    }

    [Fact]
    public async Task GetHistoricalWeatherAsync_ValidParameters_ReturnsValidWeatherData()
    {
        // Arrange
        var city = "Seattle";
        var startDate = DateTime.Today.AddDays(-7);
        var endDate = DateTime.Today.AddDays(-1);

        // Act
        var historicalData = await _weatherService.GetHistoricalWeatherAsync(city, startDate, endDate);

        // Assert
        Assert.All(historicalData, data =>
        {
            Assert.Equal(city, data.City);
            Assert.InRange(data.Temperature, 5, 35);
            Assert.InRange(data.Humidity, 40, 80);
            Assert.InRange(data.Pressure, 1000, 1030);
            Assert.InRange(data.WindSpeed, 0, 12);
            Assert.InRange(data.WindDirection, 0, 359);
            Assert.InRange(data.CloudCoverage, 10, 90);
            Assert.InRange(data.Visibility, 10, 25);
        });
    }
}
