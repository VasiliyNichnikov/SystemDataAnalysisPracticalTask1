using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalTask1.Utils
{
    public static class TranslationToObjectsFromJson
    {
        public static IList<DepartmentBase> Departments { get; }

        public static IList<EmployeeBase> Staff { get; }

        private static readonly Dictionary<int, DepartmentBase> _cacheDepartments;
        private static readonly Dictionary<int, EmployeeBase> _cacheStaff;

        static TranslationToObjectsFromJson()
        {
            _cacheDepartments = new Dictionary<int, DepartmentBase>();
            _cacheStaff = new Dictionary<int, EmployeeBase>();

            CreateAllStaff();
            LinkSubordinates();
            CreateAllDepartments();

            Departments = TranslateDictionaryToList(_cacheDepartments);
            Staff = TranslateDictionaryToList(_cacheStaff);
        }

        private static void CreateAllDepartments()
        {
            var departments = DeserializeData.Departments;
            foreach (var departmentJson in departments)
            {
                var createdDepartment = CreateDepartment(departmentJson);
                if (_cacheDepartments.ContainsKey(departmentJson.Id) == false)
                {
                    _cacheDepartments[departmentJson.Id] = createdDepartment;
                }
            }
        }

        private static void CreateAllStaff()
        {
            var staff = DeserializeData.Staff;
            foreach (var employeeJson in staff)
            {
                var createdEmployee = CreateEmployee(employeeJson);
                if (_cacheStaff.ContainsKey(employeeJson.Id) == false)
                {
                    _cacheStaff[employeeJson.Id] = createdEmployee;
                }
            }
        }

        /// <summary>
        /// Соединяем сотрудников друг к другу
        /// </summary>
        private static void LinkSubordinates()
        {
            if (_cacheStaff.Count == 0)
            {
                return;
            }

            var staff = DeserializeData.Staff;

            foreach (var employeeJson in staff)
            {
                if (employeeJson.Subordinates == null || _cacheStaff.ContainsKey(employeeJson.Id) == false)
                {
                    continue;
                }

                var mainEmployee = _cacheStaff[employeeJson.Id];
                foreach (var key in employeeJson.Subordinates)
                {
                    if (_cacheStaff.ContainsKey(key) == false)
                    {
                        continue;
                    }

                    var subordinateEmployee = _cacheStaff[key];
                    mainEmployee.AddSubordinate(subordinateEmployee);
                }
            }
        }

        private static DepartmentBase CreateDepartment(Department departmentJson)
        {
            var selectedType = (TypeDepartment)departmentJson.Id;
            var creatorDepartment = DepartmentCreator.GetCreator(selectedType);
            creatorDepartment.Init(departmentJson.Name);


            var department = creatorDepartment.Create();

            if (departmentJson.Workers == null)
            {
                return department;
            }

            foreach (var employeeIndex in departmentJson.Workers)
            {
                if (_cacheStaff.ContainsKey(employeeIndex) == false)
                {
                    continue; // todo лучше выкидывать ошибку
                }

                var employee = _cacheStaff[employeeIndex];
                department.AddEmployee(employee);
                employee.SetDepartment(department);

                if (employee is EmployeeWithoutDepartment employeeWithoutDepartment)
                {
                    _cacheStaff[employeeIndex] = employeeWithoutDepartment.RecreateWithDepartment(selectedType);
                }
            }

            return department;
        }

        private static EmployeeBase CreateEmployee(Staff employee)
        {
            var selectedType = TypeDepartment.None;
            var creatorEmployee = EmployeeCreator.GetCreator(selectedType);
            creatorEmployee.Init(new DataBaseEmployee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                MiddleName = employee.MiddleName,
                Age = employee.Age,
                Salary = employee.Salary,
                PhoneNumber = employee.PhoneNumber
            });
            return creatorEmployee.Create();
        }

        private static IList<T> TranslateDictionaryToList<T>(IDictionary<int, T> dict)
        {
            var keys = dict.Keys.ToList();
            return keys.Select(key => dict[key]).ToList();
        }
    }
}