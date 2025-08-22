using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

/// <summary>
/// Controller for weather-related operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<WeatherController> _logger;

    public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    /// <summary>
    /// Get weather forecast for the next 5 days
    /// </summary>
    /// <returns>Weather forecast data</returns>
    [HttpGet("forecast")]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetForecast()
    {
        try
        {
            _logger.LogInformation("Getting weather forecast");
            var forecast = await _weatherService.GetForecastAsync();
            return Ok(forecast);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting weather forecast");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get current weather for a specific city
    /// </summary>
    /// <param name="city">City name</param>
    /// <returns>Current weather data</returns>
    [HttpGet("current/{city}")]
    public async Task<ActionResult<WeatherData>> GetCurrentWeather(string city)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City name is required");
            }

            _logger.LogInformation("Getting current weather for {City}", city);
            var weather = await _weatherService.GetCurrentWeatherAsync(city);
            
            if (weather == null)
            {
                return NotFound($"Weather data not found for {city}");
            }

            return Ok(weather);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting current weather for {City}", city);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Get historical weather data for a city and date range
    /// </summary>
    /// <param name="city">City name</param>
    /// <param name="startDate">Start date</param>
    /// <param name="endDate">End date</param>
    /// <returns>Historical weather data</returns>
    [HttpGet("history/{city}")]
    public async Task<ActionResult<IEnumerable<WeatherData>>> GetHistoricalWeather(
        string city, 
        [FromQuery] DateTime startDate, 
        [FromQuery] DateTime endDate)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City name is required");
            }

            if (startDate > endDate)
            {
                return BadRequest("Start date cannot be later than end date");
            }

            if (endDate > DateTime.Today)
            {
                return BadRequest("End date cannot be in the future");
            }

            _logger.LogInformation("Getting historical weather for {City} from {StartDate} to {EndDate}", 
                city, startDate, endDate);

            var historicalData = await _weatherService.GetHistoricalWeatherAsync(city, startDate, endDate);
            return Ok(historicalData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting historical weather for {City}", city);
            return StatusCode(500, "Internal server error");
        }
    }
}
