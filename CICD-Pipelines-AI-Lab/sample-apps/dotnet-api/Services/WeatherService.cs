using WeatherApi.Models;

namespace WeatherApi.Services;

/// <summary>
/// Interface for weather service operations
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Get weather forecast for the next 5 days
    /// </summary>
    /// <returns>Weather forecast data</returns>
    Task<IEnumerable<WeatherForecast>> GetForecastAsync();

    /// <summary>
    /// Get current weather for a specific city
    /// </summary>
    /// <param name="city">City name</param>
    /// <returns>Current weather data</returns>
    Task<WeatherData?> GetCurrentWeatherAsync(string city);

    /// <summary>
    /// Get historical weather data for a city and date range
    /// </summary>
    /// <param name="city">City name</param>
    /// <param name="startDate">Start date</param>
    /// <param name="endDate">End date</param>
    /// <returns>Historical weather data</returns>
    Task<IEnumerable<WeatherData>> GetHistoricalWeatherAsync(string city, DateTime startDate, DateTime endDate);
}

/// <summary>
/// Weather service implementation with mock data for demonstration
/// </summary>
public class WeatherService : IWeatherService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Cities = new[]
    {
        "Seattle", "Portland", "San Francisco", "Los Angeles", "Denver", "Chicago", "New York", "Boston", "Miami", "Atlanta"
    };

    private static readonly string[] Descriptions = new[]
    {
        "Clear sky", "Few clouds", "Scattered clouds", "Broken clouds", "Overcast", 
        "Light rain", "Moderate rain", "Heavy rain", "Light snow", "Heavy snow"
    };

    private readonly Random _random = new();

    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync()
    {
        // Simulate async operation
        await Task.Delay(100);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = _random.Next(-20, 55),
            Summary = Summaries[_random.Next(Summaries.Length)],
            Humidity = _random.Next(30, 90),
            WindSpeed = Math.Round(_random.NextDouble() * 20, 1)
        }).ToArray();
    }

    public async Task<WeatherData?> GetCurrentWeatherAsync(string city)
    {
        // Simulate async operation
        await Task.Delay(150);

        // Return null for unknown cities to test error handling
        if (!Cities.Contains(city, StringComparer.OrdinalIgnoreCase))
        {
            return null;
        }

        return new WeatherData
        {
            City = city,
            DateTime = DateTime.UtcNow,
            Temperature = Math.Round(_random.NextDouble() * 40 - 10, 1),
            FeelsLike = Math.Round(_random.NextDouble() * 40 - 10, 1),
            Description = Descriptions[_random.Next(Descriptions.Length)],
            Humidity = _random.Next(30, 90),
            Pressure = Math.Round(_random.NextDouble() * 50 + 990, 1),
            WindSpeed = Math.Round(_random.NextDouble() * 15, 1),
            WindDirection = _random.Next(0, 360),
            CloudCoverage = _random.Next(0, 100),
            Visibility = Math.Round(_random.NextDouble() * 20 + 5, 1)
        };
    }

    public async Task<IEnumerable<WeatherData>> GetHistoricalWeatherAsync(string city, DateTime startDate, DateTime endDate)
    {
        // Simulate async operation
        await Task.Delay(200);

        var days = (endDate - startDate).Days + 1;
        var historicalData = new List<WeatherData>();

        for (int i = 0; i < days; i++)
        {
            var date = startDate.AddDays(i);
            historicalData.Add(new WeatherData
            {
                City = city,
                DateTime = date,
                Temperature = Math.Round(_random.NextDouble() * 30 + 5, 1),
                FeelsLike = Math.Round(_random.NextDouble() * 30 + 5, 1),
                Description = Descriptions[_random.Next(Descriptions.Length)],
                Humidity = _random.Next(40, 80),
                Pressure = Math.Round(_random.NextDouble() * 30 + 1000, 1),
                WindSpeed = Math.Round(_random.NextDouble() * 12, 1),
                WindDirection = _random.Next(0, 360),
                CloudCoverage = _random.Next(10, 90),
                Visibility = Math.Round(_random.NextDouble() * 15 + 10, 1)
            });
        }

        return historicalData;
    }
}
