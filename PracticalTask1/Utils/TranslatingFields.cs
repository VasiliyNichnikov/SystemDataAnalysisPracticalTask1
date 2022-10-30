using System;
using System.Collections.Generic;

namespace PracticalTask1.Utils
{
    public static class TranslatingFields
    {
        private static readonly Dictionary<string, string> _employee = new Dictionary<string, string>
        {
            { "_name", "Имя сотрудника" },
            { "_surname", "Фамилия сотрудника" },
            { "_middleName", "Отчество сотрудника" },
            { "_age", "Возвраст сотрудника" },
            { "_salary", "Зарплата сотрудника" },
            { "_phoneNumber", "Номер телефона сотрудника" }
        };

        public static string GetTranslateForEmployee(string nameField)
        {
            if (_employee.ContainsKey(nameField) == false)
            {
                throw new Exception(); // todo отфильтровать ошибку
            }

            return _employee[nameField];
        }
    }
}