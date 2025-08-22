namespace WeatherApi.Models;

/// <summary>
/// Weather forecast data model
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Date of the forecast
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Temperature in Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Temperature in Fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Weather condition summary
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Humidity percentage
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Wind speed in km/h
    /// </summary>
    public double WindSpeed { get; set; }
}

/// <summary>
/// Current weather data model
/// </summary>
public class WeatherData
{
    /// <summary>
    /// City name
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Date and time of the weather data
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Temperature in Celsius
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// Feels like temperature in Celsius
    /// </summary>
    public double FeelsLike { get; set; }

    /// <summary>
    /// Weather condition description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Humidity percentage
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Atmospheric pressure in hPa
    /// </summary>
    public double Pressure { get; set; }

    /// <summary>
    /// Wind speed in m/s
    /// </summary>
    public double WindSpeed { get; set; }

    /// <summary>
    /// Wind direction in degrees
    /// </summary>
    public int WindDirection { get; set; }

    /// <summary>
    /// Cloud coverage percentage
    /// </summary>
    public int CloudCoverage { get; set; }

    /// <summary>
    /// Visibility in kilometers
    /// </summary>
    public double Visibility { get; set; }
}
