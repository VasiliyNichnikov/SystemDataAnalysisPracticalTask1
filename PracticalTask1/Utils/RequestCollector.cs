namespace PracticalTask1.Utils
{
    public class RequestCollector
    {
        /// <summary>
        /// Добавление имени в поиск
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RequestCollector AddName(string name)
        {
            EmployeeBase.SelectSearchField("_name", name);

            return this;
        }

        /// <summary>
        /// Добавление фамилии в поиск
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public RequestCollector AddSurname(string surname)
        {
            EmployeeBase.SelectSearchField("_surname", surname);

            return this;
        }

        /// <summary>
        /// Добавляет отчество в поиск
        /// </summary>
        /// <param name="middleName"></param>
        /// <returns></returns>
        public RequestCollector AddMiddleName(string middleName)
        {
            EmployeeBase.SelectSearchField("_middleName", middleName);

            return this;
        }

        /// <summary>
        /// Добавление возвраста в поиск
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public RequestCollector AddAge(int age)
        {
            EmployeeBase.SelectSearchField("_age", age);
            
            return this;
        }

        /// <summary>
        /// Добавить зарплату в поиск
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public RequestCollector AddSalary(float salary)
        {
            EmployeeBase.SelectSearchField("_salary", salary);
            
            return this;
        }

        /// <summary>
        /// Добавить номер телефона в поиск
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public RequestCollector AddPhoneNumber(long phoneNumber)
        {
            EmployeeBase.SelectSearchField("_phoneNumber", phoneNumber);

            return this;
        }

        /// <summary>
        /// Очистка поиска
        /// </summary>
        public void ClearSearch()
        {
            EmployeeBase.ClearSearch();
        }
    }
}