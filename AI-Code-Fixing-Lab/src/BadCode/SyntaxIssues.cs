using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCode
{
    // PROBLEM CATEGORY: Syntax Issues, Deprecated Methods, and Poor Coding Practices
    // This class demonstrates various syntax and style problems that AI should help fix
    
    public class SyntaxIssues
    {
        // ISSUE #1: Using deprecated/obsolete methods
        public void ProcessFiles()
        {
            // Using obsolete method - should use Environment.GetFolderPath
            string tempPath = Environment.GetEnvironmentVariable("TEMP");
            
            // Using deprecated File.Exists check pattern
            FileInfo fileInfo = new FileInfo(tempPath + "\\test.txt");
            if (File.Exists(fileInfo.FullName) == true) // Redundant == true
            {
                // Should use File.ReadAllText instead
                StreamReader reader = new StreamReader(fileInfo.FullName);
                string content = reader.ReadToEnd();
                reader.Close(); // Should use using statement
                
                Console.WriteLine(content);
            }
        }

        // ISSUE #2: Poor exception handling patterns
        public int ParseUserInput(string input)
        {
            int result = 0;
            try
            {
                result = int.Parse(input); // Should use TryParse
            }
            catch (Exception ex) // Too broad exception type
            {
                throw ex; // Loses stack trace, should be just 'throw'
            }
            finally
            {
                // Empty finally block
            }
            return result;
        }

        // ISSUE #3: Missing null checks and defensive programming
        public string ProcessName(string firstName, string lastName)
        {
            // No null checks!
            string fullName = firstName.Trim() + " " + lastName.Trim();
            
            // Using old string methods
            if (fullName.IndexOf("Mr.") >= 0) // Should use Contains
            {
                fullName = fullName.Replace("Mr.", ""); // Multiple string operations
            }
            
            return fullName.ToUpper(); // Should consider culture
        }

        // ISSUE #4: Outdated loop patterns and LINQ usage
        public List<string> FilterNames(List<string> names)
        {
            List<string> filteredNames = new List<string>(); // Could use var
            
            // Old-style foreach when LINQ would be better
            foreach (string name in names)
            {
                if (name != null && name.Length > 2)
                {
                    filteredNames.Add(name.ToUpper());
                }
            }
            
            // Manual sorting instead of OrderBy
            for (int i = 0; i < filteredNames.Count - 1; i++)
            {
                for (int j = i + 1; j < filteredNames.Count; j++)
                {
                    if (string.Compare(filteredNames[i], filteredNames[j]) > 0)
                    {
                        string temp = filteredNames[i];
                        filteredNames[i] = filteredNames[j];
                        filteredNames[j] = temp;
                    }
                }
            }
            
            return filteredNames;
        }

        // ISSUE #5: Poor async/await usage
        public void DownloadDataBadly()
        {
            // Blocking on async methods - defeats the purpose
            var httpClient = new System.Net.Http.HttpClient();
            var response = httpClient.GetAsync("https://api.example.com/data").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            
            // Not disposing HttpClient
            Console.WriteLine(content);
        }

        // ISSUE #6: Using obsolete DateTime methods
        public string FormatCurrentTime()
        {
            // Should use DateTimeOffset for better timezone handling
            DateTime now = DateTime.Now;
            
            // Old formatting approach
            string formatted = now.Day.ToString() + "/" + 
                              now.Month.ToString() + "/" + 
                              now.Year.ToString();
            
            return formatted;
        }

        // ISSUE #7: Poor collection initialization and manipulation
        public Dictionary<string, int> CreateLookup()
        {
            // Old-style dictionary initialization
            Dictionary<string, int> lookup = new Dictionary<string, int>();
            lookup.Add("one", 1);
            lookup.Add("two", 2);
            lookup.Add("three", 3);
            
            // No duplicate key checking
            try
            {
                lookup.Add("one", 1); // Will throw exception
            }
            catch
            {
                // Silently ignore - bad practice
            }
            
            return lookup;
        }

        // ISSUE #8: Improper string comparison
        public bool CheckPassword(string userPassword, string correctPassword)
        {
            // Case-sensitive comparison when it shouldn't be
            // Also vulnerable to timing attacks
            if (userPassword.ToLower() == correctPassword.ToLower())
            {
                return true;
            }
            else
            {
                return false; // Unnecessary else clause
            }
        }

        // ISSUE #9: Poor resource management with IDisposable
        public void ReadConfigFile(string filename)
        {
            FileStream stream = null;
            StreamReader reader = null;
            
            try
            {
                stream = new FileStream(filename, FileMode.Open);
                reader = new StreamReader(stream);
                
                string config = reader.ReadToEnd();
                Console.WriteLine(config);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Manual disposal instead of using statements
                if (reader != null)
                    reader.Close();
                if (stream != null)
                    stream.Close();
            }
        }

        // ISSUE #10: Using reflection unnecessarily
        public void SetPropertyValue(object obj, string propertyName, object value)
        {
            // Complex reflection when simple property access would work
            Type type = obj.GetType();
            var property = type.GetProperty(propertyName);
            
            if (property != null && property.CanWrite)
            {
                property.SetValue(obj, value, null); // Null index parameter
            }
        }

        // ISSUE #11: Poor error messages and magic numbers
        public void ValidateAge(int age)
        {
            if (age < 0)
            {
                throw new Exception("Bad age"); // Vague error message
            }
            
            if (age > 150) // Magic number
            {
                throw new Exception("Age too high"); // Should use specific exception type
            }
        }

        // ISSUE #12: Inefficient string operations
        public string CleanupText(string text)
        {
            // Multiple string operations creating many intermediate strings
            text = text.Replace("  ", " "); // Only handles double spaces
            text = text.Replace("\t", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\r", " ");
            text = text.Trim();
            
            // Manual case conversion
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= 'a' && chars[i] <= 'z')
                {
                    chars[i] = (char)(chars[i] - 32); // Magic number for ASCII conversion
                }
            }
            
            return new string(chars);
        }

        // ISSUE #13: Poor enumeration handling
        public void ProcessItems(IEnumerable<string> items)
        {
            // Multiple enumeration of IEnumerable
            Console.WriteLine($"Processing {items.Count()} items");
            
            foreach (var item in items)
            {
                Console.WriteLine($"Item: {item}");
            }
            
            // Third enumeration
            var firstItem = items.FirstOrDefault();
            Console.WriteLine($"First item: {firstItem}");
        }

        // ISSUE #14: Using deprecated collection methods
        public void WorkWithArrays()
        {
            int[] numbers = new int[5];
            
            // Using Array.Copy when newer methods exist
            int[] copy = new int[5];
            Array.Copy(numbers, copy, numbers.Length);
            
            // Manual array searching instead of LINQ
            bool found = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 42)
                {
                    found = true;
                    break;
                }
            }
        }
    }
}
