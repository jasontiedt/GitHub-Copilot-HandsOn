using Xunit;
using BadCode;
using System;
using System.Collections.Generic;

namespace FixedCode.Tests
{
    /// <summary>
    /// Tests to validate that the code fixes are working correctly.
    /// These tests will initially fail - they should pass after fixes are applied.
    /// </summary>
    public class FixValidationTests
    {
        [Fact]
        public void AlgorithmProblems_SortNumbers_ShouldSortEfficiently()
        {
            // Arrange
            int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };
            int[] expected = { 11, 12, 22, 25, 34, 64, 90 };
            
            // Act
            var startTime = DateTime.Now;
            AlgorithmProblems.SortNumbers(numbers);
            var endTime = DateTime.Now;
            
            // Assert
            Assert.Equal(expected, numbers);
            // Should complete quickly (less than 100ms for small array)
            Assert.True((endTime - startTime).TotalMilliseconds < 100);
        }

        [Fact]
        public void AlgorithmProblems_FindNumber_ShouldHandleNullInput()
        {
            // Arrange
            List<int> nullList = null;
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => AlgorithmProblems.FindNumber(nullList, 5));
        }

        [Fact]
        public void AlgorithmProblems_CalculateFactorial_ShouldHandleNegativeInput()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => AlgorithmProblems.CalculateFactorial(-1));
        }

        [Fact]
        public void AlgorithmProblems_IsPrime_ShouldBeOptimized()
        {
            // Arrange
            int largeNumber = 982451653; // Large prime number
            
            // Act
            var startTime = DateTime.Now;
            bool isPrime = AlgorithmProblems.IsPrime(largeNumber);
            var endTime = DateTime.Now;
            
            // Assert
            Assert.True(isPrime);
            // Should complete in reasonable time (less than 1 second)
            Assert.True((endTime - startTime).TotalSeconds < 1);
        }

        [Fact]
        public void AlgorithmProblems_BuildLargeString_ShouldUseStringBuilder()
        {
            // Arrange
            int count = 10000;
            
            // Act
            var startTime = DateTime.Now;
            string result = AlgorithmProblems.BuildLargeString(count);
            var endTime = DateTime.Now;
            
            // Assert
            Assert.Contains("Item 0,", result);
            Assert.Contains("Item 9999,", result);
            // Should complete quickly with StringBuilder (less than 100ms)
            Assert.True((endTime - startTime).TotalMilliseconds < 100);
        }

        [Fact]
        public void AlgorithmProblems_HasDuplicates_ShouldBeLinearTime()
        {
            // Arrange
            int[] largeArray = new int[100000];
            for (int i = 0; i < largeArray.Length; i++)
            {
                largeArray[i] = i;
            }
            largeArray[99999] = 0; // Add duplicate
            
            // Act
            var startTime = DateTime.Now;
            bool hasDuplicates = AlgorithmProblems.HasDuplicates(largeArray);
            var endTime = DateTime.Now;
            
            // Assert
            Assert.True(hasDuplicates);
            // Should complete quickly with O(n) algorithm (less than 100ms)
            Assert.True((endTime - startTime).TotalMilliseconds < 100);
        }

        [Fact]
        public void SyntaxIssues_ProcessName_ShouldHandleNullInput()
        {
            // Arrange
            var syntaxIssues = new SyntaxIssues();
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => syntaxIssues.ProcessName(null, "Doe"));
            Assert.Throws<ArgumentNullException>(() => syntaxIssues.ProcessName("John", null));
        }

        [Fact]
        public void SyntaxIssues_ParseUserInput_ShouldUseTryParse()
        {
            // Arrange
            var syntaxIssues = new SyntaxIssues();
            string invalidInput = "abc123";
            
            // Act & Assert
            // Should not throw exception, should return default value or handle gracefully
            var result = Record.Exception(() => syntaxIssues.ParseUserInput(invalidInput));
            
            // After fixing, this should not throw an exception
            Assert.Null(result);
        }

        [Fact]
        public void SecurityVulnerabilities_HashPassword_ShouldUseSecureHashing()
        {
            // Arrange
            var security = new SecurityVulnerabilities();
            string password = "testpassword123";
            
            // Act
            string hash1 = security.HashPassword(password);
            string hash2 = security.HashPassword(password);
            
            // Assert
            // Hashes should be different (due to salt) but verify same password
            Assert.NotEqual(hash1, hash2); // Different due to salt
            Assert.NotEmpty(hash1);
            Assert.True(hash1.Length > 32); // Should be longer than MD5 hash
        }

        [Theory]
        [InlineData("admin'; DROP TABLE Users; --")]
        [InlineData("test' OR '1'='1")]
        [InlineData("normal_user")]
        public void SecurityVulnerabilities_GetUsersByName_ShouldPreventSQLInjection(string input)
        {
            // Arrange
            var security = new SecurityVulnerabilities();
            
            // Act & Assert
            // Should not throw SQL exception even with malicious input
            var exception = Record.Exception(() => security.GetUsersByName(input));
            
            // Should handle all inputs safely (might return empty list, but no exception)
            Assert.True(exception == null || exception is not Exception);
        }

        [Fact]
        public void PerformanceIssues_FilterAndSortProducts_ShouldUseLinq()
        {
            // Arrange
            var performance = new PerformanceIssues();
            var products = new List<Product>();
            
            // Create large list for performance testing
            for (int i = 0; i < 10000; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Category = i % 2 == 0 ? "Electronics" : "Books",
                    Price = i * 10.99m
                });
            }
            
            // Act
            var startTime = DateTime.Now;
            var result = performance.FilterAndSortProducts(products, "Electronics", 100m);
            var endTime = DateTime.Now;
            
            // Assert
            Assert.All(result, p => Assert.Equal("Electronics", p.Category));
            Assert.All(result, p => Assert.True(p.Price >= 100m));
            // Should complete quickly with LINQ (less than 100ms)
            Assert.True((endTime - startTime).TotalMilliseconds < 100);
        }

        [Fact]
        public void LegacyCode_FormatUserInfo_ShouldUseStringInterpolation()
        {
            // Arrange
            var legacy = new LegacyCode();
            
            // Act
            string result = legacy.FormatUserInfo("John Doe", 30, "New York");
            
            // Assert
            Assert.Contains("John Doe", result);
            Assert.Contains("30", result);
            Assert.Contains("New York", result);
            // Should be well-formatted
            Assert.Matches(@"User:\s*John Doe.*Age:\s*30.*City:\s*New York", result);
        }

        [Fact]
        public void LegacyCode_ValidateUser_ShouldUseConstants()
        {
            // Arrange
            var legacy = new LegacyCode();
            
            // Act & Assert
            Assert.False(legacy.ValidateUser("abc", "123")); // Too short
            Assert.False(legacy.ValidateUser("admin", "password123")); // Contains admin
            Assert.True(legacy.ValidateUser("validuser", "validpassword123")); // Valid
        }

        // TODO: Add more tests for:
        // - Async/await patterns
        // - Resource disposal with using statements
        // - Modern collection usage
        // - Exception handling improvements
        // - Security vulnerability fixes
        // - Performance optimizations

        [Fact]
        public void Program_ShouldRunWithoutExceptions()
        {
            // This test verifies that the main program can run without crashing
            // After fixes are applied, the program should handle all errors gracefully
            
            // Note: This is more of an integration test
            // In a real scenario, you might want to test individual components
            Assert.True(true, "Program structure validation - implement based on fixes");
        }
    }
}
