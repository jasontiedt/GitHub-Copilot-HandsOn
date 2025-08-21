namespace Library;

/// <summary>
/// A simple calculator class to demonstrate basic xUnit testing concepts.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Adds two numbers together.
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Sum of a and b</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtracts the second number from the first.
    /// </summary>
    /// <param name="a">Number to subtract from</param>
    /// <param name="b">Number to subtract</param>
    /// <returns>Difference of a and b</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <summary>
    /// Multiplies two numbers together.
    /// </summary>
    /// <param name="a">First number</param>
    /// <param name="b">Second number</param>
    /// <returns>Product of a and b</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Divides the first number by the second.
    /// </summary>
    /// <param name="a">Dividend</param>
    /// <param name="b">Divisor</param>
    /// <returns>Quotient of a and b</returns>
    /// <exception cref="DivideByZeroException">Thrown when b is zero</exception>
    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        
        return a / b;
    }

    /// <summary>
    /// Calculates the power of a number.
    /// </summary>
    /// <param name="baseNumber">Base number</param>
    /// <param name="exponent">Exponent</param>
    /// <returns>baseNumber raised to the power of exponent</returns>
    public double Power(double baseNumber, double exponent)
    {
        return Math.Pow(baseNumber, exponent);
    }

    /// <summary>
    /// Calculates the square root of a number.
    /// </summary>
    /// <param name="number">Number to calculate square root for</param>
    /// <returns>Square root of the number</returns>
    /// <exception cref="ArgumentException">Thrown when number is negative</exception>
    public double SquareRoot(double number)
    {
        if (number < 0)
            throw new ArgumentException("Cannot calculate square root of negative number");
        
        return Math.Sqrt(number);
    }
}
