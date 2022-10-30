using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PracticalTask1.Utils
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public float Salary { get; set; }
        public IList<int>? Subordinates { get; set; }
        public long PhoneNumber { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<int>? Workers { get; set; }
    }

    public class DataJson
    {
        public IList<Department>? Departments { get; set; }
        public IList<Staff>? Staff { get; set; }
    }
    
    public static class DeserializeData
    {
        public static IReadOnlyCollection<Department> Departments {
            get
            {
                if (Data != null)
                {
                    return Data.Departments as IReadOnlyCollection<Department>;
                }

                return new List<Department>();
            }
        }

        public static IReadOnlyCollection<Staff> Staff
        {
            get
            {
                if (Data != null)
                {
                    return Data.Staff as IReadOnlyCollection<Staff>;
                }

                return new List<Staff>();
            }
        }

        private static readonly DataJson Data;
        
        static DeserializeData()
        {
            string path = PathHandler.GetDataPath();
            using(StreamReader readText = new StreamReader(path))
            {
                string textJson = readText.ReadToEnd();
                Data = JsonSerializer.Deserialize<DataJson>(textJson);
            }
        }
    }
}