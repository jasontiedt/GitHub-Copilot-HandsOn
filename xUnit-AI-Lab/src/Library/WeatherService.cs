using System.Text.Json;

namespace Library;

/// <summary>
/// Service for getting weather information from an external API.
/// Demonstrates testing with external dependencies.
/// </summary>
public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly int _maxRetries;

    public WeatherService(HttpClient httpClient, string apiKey, int maxRetries = 3)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _apiKey = string.IsNullOrWhiteSpace(apiKey) ? throw new ArgumentException("API key cannot be empty") : apiKey;
        _maxRetries = maxRetries > 0 ? maxRetries : throw new ArgumentException("Max retries must be positive");
    }

    /// <summary>
    /// Gets current weather for a city.
    /// </summary>
    /// <param name="city">City name</param>
    /// <returns>Weather information</returns>
    /// <exception cref="ArgumentException">Thrown when city is empty</exception>
    /// <exception cref="WeatherServiceException">Thrown when API call fails</exception>
    public async Task<WeatherInfo> GetCurrentWeatherAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty", nameof(city));

        var url = $"https://api.weather.com/v1/current?key={_apiKey}&city={Uri.EscapeDataString(city)}";

        for (int attempt = 1; attempt <= _maxRetries; attempt++)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(json);
                    
                    return new WeatherInfo(
                        city,
                        weatherData.Temperature,
                        weatherData.Humidity,
                        weatherData.Description,
                        DateTime.UtcNow
                    );
                }
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new WeatherServiceException($"City '{city}' not found");
                }
                
                if (attempt == _maxRetries)
                {
                    throw new WeatherServiceException($"Weather service unavailable after {_maxRetries} attempts");
                }
                
                // Wait before retry
                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt - 1)));
            }
            catch (HttpRequestException ex) when (attempt < _maxRetries)
            {
                // Log and retry
                await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt - 1)));
            }
            catch (HttpRequestException ex) when (attempt == _maxRetries)
            {
                throw new WeatherServiceException("Network error occurred", ex);
            }
        }

        throw new WeatherServiceException("Unexpected error occurred");
    }

    /// <summary>
    /// Gets weather forecast for multiple days.
    /// </summary>
    /// <param name="city">City name</param>
    /// <param name="days">Number of days (1-7)</param>
    /// <returns>Weather forecast</returns>
    public async Task<WeatherForecast> GetForecastAsync(string city, int days = 5)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty", nameof(city));
        
        if (days < 1 || days > 7)
            throw new ArgumentException("Days must be between 1 and 7", nameof(days));

        var url = $"https://api.weather.com/v1/forecast?key={_apiKey}&city={Uri.EscapeDataString(city)}&days={days}";

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var forecastData = JsonSerializer.Deserialize<WeatherForecastResponse>(json);
            
            return new WeatherForecast(
                city,
                forecastData.Days.Select(d => new DailyWeather(
                    d.Date,
                    d.HighTemp,
                    d.LowTemp,
                    d.Description
                )).ToList()
            );
        }
        catch (HttpRequestException ex)
        {
            throw new WeatherServiceException("Failed to get weather forecast", ex);
        }
    }

    /// <summary>
    /// Checks if the weather service is available.
    /// </summary>
    /// <returns>True if service is available</returns>
    public async Task<bool> IsServiceAvailableAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://api.weather.com/v1/health");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}

public record WeatherInfo(
    string City,
    double Temperature,
    int Humidity,
    string Description,
    DateTime Timestamp
);

public record WeatherForecast(
    string City,
    List<DailyWeather> Days
);

public record DailyWeather(
    DateTime Date,
    double HighTemp,
    double LowTemp,
    string Description
);

public class WeatherServiceException : Exception
{
    public WeatherServiceException(string message) : base(message) { }
    public WeatherServiceException(string message, Exception innerException) : base(message, innerException) { }
}

// API Response DTOs
internal record WeatherApiResponse(
    double Temperature,
    int Humidity,
    string Description
);

internal record WeatherForecastResponse(
    List<ForecastDay> Days
);

internal record ForecastDay(
    DateTime Date,
    double HighTemp,
    double LowTemp,
    string Description
);
