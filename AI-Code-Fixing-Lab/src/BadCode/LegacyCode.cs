using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Old namespace! Should be updated
using System.IO;
using System.Threading;

namespace BadCode
{
    // PROBLEM CATEGORY: Legacy Code and Outdated Patterns
    // This class demonstrates old patterns and approaches that should be modernized
    
    public class LegacyCode
    {
        // ISSUE #1: Using obsolete SqlConnection instead of Microsoft.Data.SqlClient
        private SqlConnection connection; // Should use Microsoft.Data.SqlClient
        private string connectionString = "Data Source=server;Initial Catalog=db;Integrated Security=true";

        // ISSUE #2: Manual threading instead of async/await
        public void ProcessDataOldWay()
        {
            // Old threading model
            Thread workerThread = new Thread(new ThreadStart(DoWork));
            workerThread.Start();
            workerThread.Join(); // Blocking main thread
        }

        private void DoWork()
        {
            // Simulate work
            Thread.Sleep(5000); // Should use Task.Delay
        }

        // ISSUE #3: Using ArrayList instead of generic collections
        public void ManageEmployees()
        {
            // Non-generic collections
            ArrayList employees = new ArrayList();
            Hashtable employeeLookup = new Hashtable();
            
            // Boxing/unboxing performance issues
            employees.Add("John Doe");
            employees.Add("Jane Smith");
            
            employeeLookup.Add(1, "John Doe");
            employeeLookup.Add(2, "Jane Smith");
            
            // Casting required
            foreach (string employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        // ISSUE #4: Manual resource management instead of using statements
        public string ReadFileOldWay(string filename)
        {
            FileStream fileStream = null;
            StreamReader reader = null;
            
            try
            {
                fileStream = new FileStream(filename, FileMode.Open);
                reader = new StreamReader(fileStream);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
                // Manual cleanup
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }

        // ISSUE #5: Old-style property declarations
        private string _name;
        private int _age;
        
        public string GetName()
        {
            return _name;
        }
        
        public void SetName(string value)
        {
            _name = value;
        }
        
        public int GetAge()
        {
            return _age;
        }
        
        public void SetAge(int value)
        {
            _age = value;
        }

        // ISSUE #6: Manual string formatting instead of interpolation
        public string FormatUserInfo(string name, int age, string city)
        {
            // Old string concatenation and formatting
            return "User: " + name + ", Age: " + age.ToString() + ", City: " + city;
        }

        // ISSUE #7: DataSet/DataTable instead of modern ORMs
        public DataSet GetCustomersOldWay()
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", connectionString);
            
            try
            {
                adapter.Fill(dataSet, "Customers");
                return dataSet;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
                return null;
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
        }

        // ISSUE #8: Manual XML handling instead of modern serialization
        public void SaveCustomerToXml(Customer customer, string filename)
        {
            // Manual XML creation
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement root = doc.CreateElement("Customer");
            doc.AppendChild(root);
            
            System.Xml.XmlElement nameElement = doc.CreateElement("Name");
            nameElement.InnerText = customer.Name;
            root.AppendChild(nameElement);
            
            System.Xml.XmlElement ageElement = doc.CreateElement("Age");
            ageElement.InnerText = customer.Age.ToString();
            root.AppendChild(ageElement);
            
            // Old save method
            doc.Save(filename);
        }

        // ISSUE #9: Events without proper cleanup
        public delegate void ProgressEventHandler(int progress);
        public event ProgressEventHandler ProgressChanged;
        
        public void ProcessWithProgress()
        {
            for (int i = 0; i <= 100; i++)
            {
                // Old event firing pattern
                if (ProgressChanged != null)
                {
                    ProgressChanged(i);
                }
                Thread.Sleep(50);
            }
        }

        // ISSUE #10: Configuration through app.config instead of modern options
        public string GetConfigValue(string key)
        {
            // Old configuration access - commented out for compilation
            // return System.Configuration.ConfigurationManager.AppSettings[key];
            return "default_value"; // Hardcoded for demo purposes
        }

        // ISSUE #11: Manual logging instead of modern logging frameworks
        public void LogMessage(string message)
        {
            // Writing directly to file
            string logPath = @"C:\Logs\application.log";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = timestamp + " - " + message + Environment.NewLine;
            
            File.AppendAllText(logPath, logEntry);
        }

        // ISSUE #12: Synchronous web requests
        public string CallWebServiceOldWay(string url)
        {
            try
            {
                // Old WebRequest pattern
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                request.Method = "GET";
                
                using (System.Net.WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                LogMessage("Web request failed: " + ex.Message);
                return null;
            }
        }

        // ISSUE #13: Manual serialization instead of System.Text.Json
        public string SerializeCustomer(Customer customer)
        {
            // Manual serialization
            return "{" +
                   "\"Name\":\"" + customer.Name + "\"," +
                   "\"Age\":" + customer.Age + "," +
                   "\"Email\":\"" + customer.Email + "\"" +
                   "}";
        }

        // ISSUE #14: Old exception handling patterns
        public void HandleExceptionsOldWay()
        {
            try
            {
                // Some risky operation
                ProcessRiskyOperation();
            }
            catch (Exception ex)
            {
                // Catching all exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                
                // Re-throwing incorrectly
                throw ex; // Loses stack trace
            }
        }

        // ISSUE #15: Manual implementation of IDisposable
        public class LegacyResource : IDisposable
        {
            private bool disposed = false;
            private FileStream fileStream;
            
            public LegacyResource(string filename)
            {
                fileStream = new FileStream(filename, FileMode.Create);
            }
            
            // Manual finalizer
            ~LegacyResource()
            {
                Dispose(false);
            }
            
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            
            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        if (fileStream != null)
                        {
                            fileStream.Dispose();
                            fileStream = null;
                        }
                    }
                    disposed = true;
                }
            }
        }

        // ISSUE #16: Old naming conventions
        public class employee_data // Should be PascalCase
        {
            public string first_name; // Should be PascalCase with property
            public string last_name;
            public int employee_id;
            
            public void update_employee_info(string fname, string lname)
            {
                first_name = fname;
                last_name = lname;
            }
        }

        // ISSUE #17: Magic strings and numbers
        public bool ValidateUser(string username, string password)
        {
            // Magic numbers and strings
            if (username.Length < 5) // Should be constant
                return false;
                
            if (password.Length < 8) // Should be constant
                return false;
                
            if (username.Contains("admin")) // Should be configurable
                return false;
                
            return true;
        }

        private void ProcessRiskyOperation()
        {
            throw new InvalidOperationException("Something went wrong");
        }
    }

    // Supporting legacy class
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
