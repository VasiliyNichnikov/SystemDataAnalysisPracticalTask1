using System.Collections.Generic;
using PracticalTask1.Algorithms;

namespace PracticalTask1
{
    public abstract class DepartmentBase
    {
        public string Name { get; }
        public IReadOnlyList<EmployeeBase> Staff => (IReadOnlyList<EmployeeBase>)_staff;

        private readonly IList<EmployeeBase> _staff;
        private static readonly FieldHandler<DepartmentBase> _fieldHandler = new();

        protected DepartmentBase(string name)
        {
            Name = name;
            _staff = new List<EmployeeBase>();
        }

        public void AddEmployee(EmployeeBase employee)
        {
            _staff.Add(employee);
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
    }
}