using System;
using BadCode;

namespace BadCode
{
    // PROBLEM CATEGORY: Main Program with Multiple Issues
    // This Program.cs demonstrates various problems that students will fix using AI
    
    class Program
    {
        // ISSUE #1: Not using async Main (available since C# 7.1)
        static void Main(string[] args)
        {
            Console.WriteLine("=== AI Code Fixing Lab - Problematic Code Demo ===");
            Console.WriteLine("This code contains numerous issues that you'll fix using AI assistance!");
            Console.WriteLine();

            try
            {
                // ISSUE #2: No proper exception handling - will likely crash
                DemonstrateAlgorithmProblems();
                DemonstrateSyntaxIssues();
                DemonstratePerformanceIssues();
                DemonstrateLegacyCode();
                
                // ISSUE #3: Not calling security demos due to danger
                // DemonstrateSecurityIssues(); // Commented out - too dangerous to run
                
                Console.WriteLine("Demo completed! Now use AI to fix all the issues.");
            }
            catch (Exception ex)
            {
                // ISSUE #4: Poor exception handling
                Console.WriteLine("Something went wrong: " + ex.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        // ISSUE #5: Methods should be async when calling async code
        static void DemonstrateAlgorithmProblems()
        {
            Console.WriteLine("--- Algorithm Problems Demo ---");
            
            try
            {
                // Demonstrating inefficient sorting
                int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };
                Console.WriteLine("Original array: " + string.Join(", ", numbers));
                
                AlgorithmProblems.SortNumbers(numbers);
                Console.WriteLine("Sorted array: " + string.Join(", ", numbers));
                
                // Demonstrating inefficient search
                var numberList = new System.Collections.Generic.List<int> { 1, 5, 3, 9, 7, 2 };
                int index = AlgorithmProblems.FindNumber(numberList, 7);
                Console.WriteLine($"Found 7 at index: {index}");
                
                // Demonstrating stack overflow risk
                Console.WriteLine("Calculating factorial of 5...");
                long factorial = AlgorithmProblems.CalculateFactorial(5);
                Console.WriteLine($"Factorial of 5: {factorial}");
                
                // Don't try large numbers - will crash!
                // long bigFactorial = AlgorithmProblems.CalculateFactorial(50000); // Stack overflow!
                
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Algorithm demo failed: {ex.Message}");
            }
        }

        static void DemonstrateSyntaxIssues()
        {
            Console.WriteLine("--- Syntax Issues Demo ---");
            
            try
            {
                var syntaxDemo = new SyntaxIssues();
                
                // This will likely fail due to file not existing
                syntaxDemo.ProcessFiles();
                
                // Demonstrating poor input parsing
                string userInput = "123abc"; // Invalid number
                int parsed = syntaxDemo.ParseUserInput(userInput); // Will throw exception
                Console.WriteLine($"Parsed: {parsed}");
                
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Syntax demo failed: {ex.Message}");
            }
        }

        static void DemonstratePerformanceIssues()
        {
            Console.WriteLine("--- Performance Issues Demo ---");
            
            try
            {
                var perfDemo = new PerformanceIssues();
                
                // This will be very slow due to inefficient algorithms
                Console.WriteLine("Calling slow API methods...");
                var apiResults = perfDemo.GetDataFromMultipleAPIs();
                Console.WriteLine($"Got {apiResults.Count} results from APIs");
                
                // This will use a lot of memory unnecessarily
                Console.WriteLine("Processing large dataset...");
                // perfDemo.ProcessLargeDataset(); // Commented out - would need actual database
                
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Performance demo failed: {ex.Message}");
            }
        }

        static void DemonstrateLegacyCode()
        {
            Console.WriteLine("--- Legacy Code Demo ---");
            
            try
            {
                var legacyDemo = new LegacyCode();
                
                // Demonstrating old threading model
                Console.WriteLine("Processing data with old threading...");
                legacyDemo.ProcessDataOldWay();
                
                // Demonstrating old collections
                Console.WriteLine("Managing employees with old collections...");
                legacyDemo.ManageEmployees();
                
                // Demonstrating manual resource management
                string tempFile = System.IO.Path.GetTempFileName();
                System.IO.File.WriteAllText(tempFile, "Test content");
                
                Console.WriteLine("Reading file with old pattern...");
                string content = legacyDemo.ReadFileOldWay(tempFile);
                Console.WriteLine($"File content length: {content?.Length ?? 0}");
                
                // Cleanup
                if (System.IO.File.Exists(tempFile))
                    System.IO.File.Delete(tempFile);
                
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Legacy demo failed: {ex.Message}");
            }
        }

        // ISSUE #6: This method demonstrates security issues but is commented out for safety
        /*
        static void DemonstrateSecurityIssues()
        {
            Console.WriteLine("--- Security Issues Demo ---");
            Console.WriteLine("DANGER: These methods contain serious security vulnerabilities!");
            Console.WriteLine("They are commented out to prevent actual harm.");
            
            var securityDemo = new SecurityVulnerabilities();
            
            // DO NOT UNCOMMENT THESE - THEY CONTAIN REAL VULNERABILITIES!
            // securityDemo.GetUsersByName("'; DROP TABLE Users; --"); // SQL Injection
            // securityDemo.SaveUserData("<script>alert('XSS')</script>", "test@test.com");
            // securityDemo.SaveUploadedFile("../../../windows/system32/evil.exe", new byte[100]);
            
            Console.WriteLine("Security demo skipped for safety.");
            Console.WriteLine();
        }
        */

        // ISSUE #7: No proper application shutdown handling
        // Missing: Console.CancelKeyPress event handler
        // Missing: Proper cleanup of resources
        // Missing: Graceful shutdown procedures
    }
}
