using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace BadCode
{
    // PROBLEM CATEGORY: Security Vulnerabilities
    // This class contains serious security issues that AI should help identify and fix
    
    public class SecurityVulnerabilities
    {
        private string connectionString = "Server=localhost;Database=TestDB;User Id=sa;Password=admin123;"; // Hardcoded credentials!

        // ISSUE #1: SQL Injection vulnerability
        public List<User> GetUsersByName(string name)
        {
            var users = new List<User>();
            
            // CRITICAL: Direct string concatenation creates SQL injection risk
            string query = "SELECT * FROM Users WHERE Name = '" + name + "'";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                Email = reader.GetString("Email")
                            });
                        }
                    }
                }
            }
            
            return users;
        }

        // ISSUE #2: No input validation - allows malicious input
        public void SaveUserData(string userInput, string email)
        {
            // No validation on user input!
            // Could contain script tags, SQL commands, or other malicious content
            
            string query = $"INSERT INTO UserData (Content, Email) VALUES ('{userInput}', '{email}')";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery(); // SQL injection vulnerability here too!
            }
        }

        // ISSUE #3: Weak password hashing
        public string HashPassword(string password)
        {
            // CRITICAL: Using MD5 which is cryptographically broken
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                // Converting to string without salt - vulnerable to rainbow table attacks
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        // ISSUE #4: Information disclosure through exception messages
        public User AuthenticateUser(string username, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);
                
                // SQL injection vulnerability AND information disclosure
                string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{hashedPassword}'";
                
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = reader.GetInt32("Id"),
                                    Name = reader.GetString("Username"),
                                    Email = reader.GetString("Email")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // SECURITY ISSUE: Exposing internal details to client
                throw new Exception($"Authentication failed: {ex.Message}\nStack trace: {ex.StackTrace}");
            }
            
            return null;
        }

        // ISSUE #5: Insecure file upload handling
        public void SaveUploadedFile(string filename, byte[] fileContent)
        {
            // No file type validation!
            // No size limits!
            // No path traversal protection!
            
            string uploadPath = @"C:\Uploads\" + filename; // Path traversal vulnerability
            
            // Could overwrite system files or save malicious executables
            File.WriteAllBytes(uploadPath, fileContent);
        }

        // ISSUE #6: Insecure random number generation
        public string GenerateSessionToken()
        {
            Random random = new Random(); // NOT cryptographically secure
            
            StringBuilder token = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                // Predictable random numbers
                token.Append(random.Next(0, 10));
            }
            
            return token.ToString();
        }

        // ISSUE #7: Sensitive data in logs
        public void LogUserActivity(string username, string password, string action)
        {
            // CRITICAL: Logging sensitive information
            string logEntry = $"{DateTime.Now}: User {username} with password {password} performed {action}";
            
            // Writing to file without encryption
            File.AppendAllText(@"C:\Logs\activity.log", logEntry + Environment.NewLine);
        }

        // ISSUE #8: No HTTPS enforcement for sensitive operations
        public void ProcessPayment(string creditCardNumber, string cvv, decimal amount)
        {
            // No validation of card number format
            // No encryption of sensitive data
            // No HTTPS check
            
            // Storing credit card info in plain text - MASSIVE security violation
            string query = $"INSERT INTO Payments (CardNumber, CVV, Amount) VALUES ('{creditCardNumber}', '{cvv}', {amount})";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        // ISSUE #9: Vulnerable XML processing
        public void ProcessXmlData(string xmlContent)
        {
            // XXE (XML External Entity) vulnerability
            var doc = new System.Xml.XmlDocument();
            doc.LoadXml(xmlContent); // Can load external entities, leading to file disclosure
            
            // Processing without validation
            Console.WriteLine(doc.InnerText);
        }

        // ISSUE #10: Insecure deserialization
        public object DeserializeUserData(string serializedData)
        {
            // Using BinaryFormatter which is insecure - commented out for compilation
            // byte[] data = Convert.FromBase64String(serializedData);
            
            // using (var stream = new MemoryStream(data))
            // {
            //     var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //     return formatter.Deserialize(stream); // Can execute arbitrary code!
            // }
            
            // Placeholder for demo purposes
            return new { Message = "Insecure deserialization example" };
        }

        // ISSUE #11: Missing access control checks
        public void DeleteUser(int userId, int requestingUserId)
        {
            // No authorization check!
            // Any user can delete any other user
            
            string query = $"DELETE FROM Users WHERE Id = {userId}";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        // ISSUE #12: Timing attack vulnerability
        public bool ValidateApiKey(string providedKey, string validKey)
        {
            // String comparison stops at first difference
            // Allows timing attacks to determine correct key
            return providedKey == validKey;
        }

        // ISSUE #13: Directory traversal vulnerability
        public string ReadConfigFile(string configName)
        {
            // No path validation - allows reading any file on system
            string filePath = @"C:\Config\" + configName;
            
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            
            return null;
        }

        // ISSUE #14: Weak encryption
        public string EncryptSensitiveData(string data)
        {
            // Using DES which is weak and deprecated
            using (DES des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes("12345678"); // Hardcoded key!
                des.IV = Encoding.UTF8.GetBytes("12345678");  // Hardcoded IV!
                
                using (var encryptor = des.CreateEncryptor())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                    cs.Write(dataBytes, 0, dataBytes.Length);
                    cs.FlushFinalBlock();
                    
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // ISSUE #15: No rate limiting
        public bool AttemptLogin(string username, string password)
        {
            // No rate limiting - allows brute force attacks
            // No account lockout mechanism
            
            return AuthenticateUser(username, password) != null;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
