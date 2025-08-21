using Library;

namespace Library.Tests;

/// <summary>
/// Example tests for the Calculator class demonstrating basic xUnit patterns.
/// Students will extend these tests using AI assistance.
/// </summary>
public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        // Arrange - Set up test dependencies
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_WithPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double a = 5;
        double b = 3;
        double expected = 8;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_WithNegativeNumbers_ReturnsCorrectSum()
    {
        // Arrange
        double a = -5;
        double b = -3;
        double expected = -8;

        // Act
        double result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 5, 5)]
    [InlineData(0, 0, 0)]
    [InlineData(-10, -5, -5)]
    [InlineData(10, -5, 15)]
    public void Subtract_WithVariousInputs_ReturnsCorrectDifference(double a, double b, double expected)
    {
        // Act
        var result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Multiply_WithPositiveNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        double a = 4;
        double b = 3;
        double expected = 12;

        // Act
        double result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_WithValidNumbers_ReturnsCorrectQuotient()
    {
        // Arrange
        double a = 10;
        double b = 2;
        double expected = 5;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        double a = 10;
        double b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void Power_WithValidInputs_ReturnsCorrectResult()
    {
        // Arrange
        double baseNumber = 2;
        double exponent = 3;
        double expected = 8;

        // Act
        double result = _calculator.Power(baseNumber, exponent);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SquareRoot_WithPositiveNumber_ReturnsCorrectResult()
    {
        // Arrange
        double number = 9;
        double expected = 3;

        // Act
        double result = _calculator.SquareRoot(number);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SquareRoot_WithNegativeNumber_ThrowsArgumentException()
    {
        // Arrange
        double number = -9;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(number));
    }

    // TODO: Students should add more tests using AI assistance:
    // 1. Test edge cases (very large numbers, very small numbers)
    // 2. Test precision with floating-point numbers
    // 3. Test zero as first operand in various operations
    // 4. Test infinity and NaN scenarios
    // 5. Add parameterized tests for comprehensive coverage
}
