using System;
using System.Collections;
using System.Collections.Generic;

namespace BadCode
{
    // PROBLEM CATEGORY: Algorithm and Performance Issues
    // This class contains multiple algorithmic problems that AI should help identify and fix
    
    public class AlgorithmProblems
    {
        // ISSUE #1: Terrible sorting algorithm - Bubble sort with worst case O(n²)
        // Also has off-by-one errors and doesn't handle edge cases
        public static void SortNumbers(int[] numbers)
        {
            if (numbers == null) return; // Missing proper validation
            
            // Inefficient bubble sort implementation
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++) // Missing optimization
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Inefficient swapping
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        // FIXED: Binary search for O(log n) performance
        // Sorts the list first, then uses efficient binary search
        public static int FindNumber(List<int> numbers, int target)
        {
            if (numbers == null || numbers.Count == 0) return -1;
            
            // Sort the list first for binary search
            numbers.Sort();
            
            // Use built-in binary search
            int index = numbers.BinarySearch(target);
            
            // BinarySearch returns negative value if not found
            return index >= 0 ? index : -1;
        }

        // ISSUE #3: Recursive factorial with no memoization and stack overflow risk
        public static long CalculateFactorial(int n)
        {
            if (n == 0) return 1; // Missing negative number check
            return n * CalculateFactorial(n - 1); // Will stack overflow for large n
        }

        // ISSUE #4: Inefficient prime number checking
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            
            // Checking all numbers up to n instead of sqrt(n)
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        // ISSUE #5: String concatenation in loop - very inefficient
        public static string BuildLargeString(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += "Item " + i + ", "; // Creates new string objects each iteration
            }
            return result;
        }

        // ISSUE #6: Memory leak - not disposing resources
        public static void ProcessLargeFile(string filename)
        {
            var file = new System.IO.FileStream(filename, System.IO.FileMode.Open);
            var reader = new System.IO.StreamReader(file);
            
            string content = reader.ReadToEnd();
            // Process content...
            Console.WriteLine($"Processed {content.Length} characters");
            
            // MISSING: file.Dispose() and reader.Dispose()
            // Should use 'using' statements
        }

        // ISSUE #7: Inefficient data structure usage
        public static bool HasDuplicates(int[] array)
        {
            // O(n²) when it could be O(n) with HashSet
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        return true;
                }
            }
            return false;
        }

        // ISSUE #8: Unnecessary boxing/unboxing with ArrayList
        public static void WorkWithNumbers()
        {
            ArrayList numbers = new ArrayList(); // Should use List<int>
            
            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i); // Boxing int to object
            }
            
            int sum = 0;
            foreach (object number in numbers)
            {
                sum += (int)number; // Unboxing - performance hit
            }
            
            Console.WriteLine($"Sum: {sum}");
        }

        // ISSUE #9: Fibonacci with exponential time complexity
        public static int CalculateFibonacci(int n)
        {
            if (n <= 1) return n;
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2); // Recalculates same values
        }

        // ISSUE #10: Exception swallowing and poor error handling
        public static int DivideNumbers(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception ex) // Too broad exception catching
            {
                Console.WriteLine("Error occurred"); // Swallowing exception details
                return 0; // Misleading return value
            }
        }

        // ISSUE #11: Inefficient array copying
        public static int[] CopyArray(int[] source)
        {
            int[] destination = new int[source.Length];
            
            // Manual copying instead of using Array.Copy or built-in methods
            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = source[i];
            }
            
            return destination;
        }

        // ISSUE #12: Poor algorithm for finding maximum element
        public static int FindMaximum(List<int> numbers)
        {
            if (numbers.Count == 0) return 0; // Should throw exception
            
            // Sorting entire array just to find max - O(n log n) instead of O(n)
            numbers.Sort();
            return numbers[numbers.Count - 1];
        }
    }
}
