using System;
using System.Collections.Generic;
using PracticalTask1.Algorithms;
using PracticalTask1.Utils;

namespace PracticalTask1
{
    static class Program
    {
        /// <summary>
        /// Нулевой пример
        /// Исключит сотрудника с именим "Марк" и фамилией "Осипов" и возврастом 54
        /// </summary>
        /// <param name="drawer"></param>
        /// <param name="requestCollector"></param>
        private static void Example0(GraphDrawer drawer, RequestCollector requestCollector)
        {
            requestCollector.ClearSearch();
            requestCollector.AddName("Марк").AddSurname("Осипов").AddAge(54);

            drawer.Draw(TypeSearch.Missing, "example0");
        }
        
        
        /// <summary>
        /// Первый пример
        /// Найдет всех пользователей у которых в фамилии присутсвует слово "Орлов"
        /// </summary>
        /// <param name="drawer"></param>
        /// <param name="requestCollector"></param>
        private static void Example1(GraphDrawer drawer, RequestCollector requestCollector)
        {
            requestCollector.ClearSearch();
            requestCollector.AddSurname("Орлов");

            drawer.Draw(TypeSearch.InPresent, "example1");
        }

        /// <summary>
        /// Второй пример
        /// Найдет пользователей у которых точно будет в имени "Марк"
        /// И ЗП равная 200тыс.
        /// </summary>
        /// <param name="drawer"></param>
        /// <param name="requestCollector"></param>
        private static void Example2(GraphDrawer drawer, RequestCollector requestCollector)
        {
            requestCollector.ClearSearch();
            requestCollector.AddName("Марк").AddSalary(200);
            
            drawer.Draw(TypeSearch.Equal, "example2");
        }

        /// <summary>
        /// Пятый вариант
        /// В данном варианте указаны несуществующие данные
        /// Поэтому в качестве ответа будет информация о том, что не удалось найти сотрудников 
        /// </summary>
        /// <param name="drawer"></param>
        /// <param name="requestCollector"></param>
        private static void Example3(GraphDrawer drawer, RequestCollector requestCollector)
        {
            requestCollector.ClearSearch();
            requestCollector.AddName("Руслан").AddMiddleName("Никитична");
            
            drawer.Draw(TypeSearch.Equal, "example3");
        }
        
        static void Main(string[] args)
        {
            var departments = TranslationToObjectsFromJson.Departments as IReadOnlyList<DepartmentBase>;
            var staff = TranslationToObjectsFromJson.Staff as IReadOnlyList<EmployeeBase>;

            if (departments == null || staff == null)
            {
                Console.WriteLine("Ошибка. Не получается получить отделы или сотрудников");
                return;
            }
            
            var drawer = new GraphDrawer(staff, departments);
            var request = new RequestCollector();

            Example0(drawer, request); // работает
            Console.WriteLine();
            Example1(drawer, request); // работает
            Console.WriteLine();
            Example2(drawer, request); // работает
            Console.WriteLine();
            Example3(drawer, request);  // работает
        }
    }
}