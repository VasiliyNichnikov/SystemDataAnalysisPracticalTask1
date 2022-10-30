using System.Collections.Generic;
using PracticalTask1.Algorithms;

namespace PracticalTask1
{
    public abstract class EmployeeBase : INode<EmployeeBase>
    {
        public EmployeeBase Data => this;
        public bool Visited { get; set; }
        public IReadOnlyList<INode<EmployeeBase>> Neighbors => Subordinates;
        public string Name => _name;
        public string Surname => _surname;
        public string MiddleName => _middleName;
        public long PhoneNumber { get; private set; }
        public int Age { get; private set; }
        public float Salary { get; private set; }
        public DepartmentBase Department { get; private set; }
        public IReadOnlyList<EmployeeBase> Subordinates => _subordinates.AsReadOnly();

        private readonly List<EmployeeBase> _subordinates = new();

        private static readonly FieldHandler<EmployeeBase> _fieldHandler = new();

        private string _name;
        private string _surname;
        private string _middleName;

        protected EmployeeBase(string name, string surname, string middleName, int age, float salary, long phoneNumber)
        {
            _name = name;
            _surname = surname;
            _middleName = middleName;
            Age = age;
            Salary = salary;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Проверяем принадлежность к верному департаменту
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public abstract bool CheckDepartment(DepartmentBase department);

        /// <summary>
        /// Выбор отдела
        /// </summary>
        /// <param name="department"></param>
        public EmployeeBase SetDepartment(DepartmentBase department)
        {
            Department = department;

            return this;
        }

        /// <summary>
        /// Добавляем подчиненного
        /// </summary>
        public void AddSubordinate(EmployeeBase employee)
        {
            if (_subordinates.Contains(employee) == false)
            {
                _subordinates.Add(employee);
            }
        }

        /// <summary>
        /// Добавляем сразу несколько сотрудников
        /// </summary>
        public void AddSubordinate(EmployeeBase[] allEmployee)
        {
            foreach (var employee in allEmployee)
            {
                AddSubordinate(employee);
            }
        }

        /// <summary>
        /// Возвращает названия полей, которые можно использовать для поиска
        /// </summary>
        /// <returns></returns>
        public static string[] GetSearchFields()
        {
            return _fieldHandler.GetSearchFields();
        }

        /// <summary>
        /// Выбираем поле, с помощью которо будем осуществлять поиски
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="searchValue"></param>
        public static void SelectSearchField(string fieldName, string searchValue)
        {
            _fieldHandler.SelectSearchField(fieldName, searchValue);
        }

        public static void SelectSearchField(string fieldName, int searchValue)
        {
            _fieldHandler.SelectSearchField(fieldName, searchValue);
        }

        public static void SelectSearchField(string fieldName, float searchValue)
        {
            _fieldHandler.SelectSearchField(fieldName, searchValue);
        }

        /// <summary>
        /// Дословная проверка, когда мы убеждаемся чтобы значения совпадали в точности
        /// todo Для строк нужно проверка на не точное совпадение
        /// </summary>
        /// <returns></returns>
        public bool CheckVerbatim()
        {
            return _fieldHandler.CheckSearchValueForSpecificObject(this);
        }
        
    }
}