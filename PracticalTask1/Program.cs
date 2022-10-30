using System;
using System.Collections.Generic;
using PracticalTask1.Algorithms;
using PracticalTask1.Utils;

namespace PracticalTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            // todo странная ошибка: мы получаем объект сотрудника без депортамента,
            // нужно найти причину возникновения
            var departments = TranslationToObjectsFromJson.Departments;
            var staff = TranslationToObjectsFromJson.Staff;

            var dfsEmployee = new DeepFindSearchGraph<EmployeeBase>();
            // EmployeeBase.SelectSearchField("_name", "Руслан");
            EmployeeBase.SelectSearchField("_surname", "Осипов");

            var nodes = dfsEmployee.FoundAllNodes(staff[4], staff[4], new List<EmployeeBase>());
            if (nodes.Count == 0)
            {
                Console.WriteLine("Not found data");
            }
            else
            {
                foreach (var node in nodes)
                {
                    Console.WriteLine($"Name: {node.Name}\nSurname: {node.Surname}\nMiddle name: {node.MiddleName}");
                }
            }
            

            // foreach (var department in departments)
            // {
            //     Console.WriteLine($"Department: {department.Name}");
            //     Console.WriteLine($"Department number staff: {department.Staff.Count}");
            //
            //     foreach (var employee in department.Staff)
            //     {
            //         Console.WriteLine($"....Employee: {employee.Name}\n" +
            //                           $"....Employee: {employee.Surname}\n" +
            //                           $"....Employee: {employee.MiddleName}\n" +
            //                           $"....Employee: {employee.Subordinates.Count}");
            //
            //         foreach (var subordinate in employee.Subordinates)
            //         {
            //             Console.WriteLine($"........Subordinate: {subordinate.Name}\n" +
            //                               $"........Subordinate: {subordinate.Surname}\n" +
            //                               $"........Subordinate: {subordinate.MiddleName}\n" +
            //                               $"........Subordinate: {subordinate.Subordinates.Count}");
            //         }
            //     }
            //     
            // }
            
            // Привязываем пользователя к департаменту и департамент к пользователю
            // Указываем данные которые хотим найти
            // 1) Указывается класс
            // 2) Указывается поле по которому будет осуществлятся поиск
            // 3) Нужно указать какое должно быть значение у выбранного поля
            
            // Пример 1:
            // Выбранный класс: DepartmentBase
            // Поле: _name
            // Значение: "выбранный департамент"
            // Итог: Получаем отдел(ы) с именим и так же разварачиваем в виде графа всех кто в нем есть из работников
            
            
            // Пример 2:
            // Выбранный класс: EmployeeBase
            // Поле: Фамилия
            // Должность: Самая высокая которая будет
            // Итог: Получаем сотрудник(а/ов) с именим и так же показываем всех подчиненных в виде графа
            
            // 1) Выбор классе
            return;
            Console.WriteLine("Введите номер класса, который хотите рассмотреть:\n" +
                              "1) Сотрудник\n" +
                              "2) Отдел");

            int numberAnswer = Convert.ToInt32(Console.ReadLine());
            if (numberAnswer == 1)
            {
                // Выбор сотрудника
                
                // 2) Выбор значения для поиска
                do
                {
                    Console.WriteLine("Введите номер по которому будет происходить поиск:\n" +
                                      "После завершения выбора введите -1 для выхода.");
                    var fields = EmployeeBase.GetSearchFields();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        var fieldName = fields[i];
                        Console.WriteLine($"{i + 1}) {TranslatingFields.GetTranslateForEmployee(fieldName)}");
                    }
                    numberAnswer = Convert.ToInt32(Console.ReadLine());
                    if (numberAnswer == -1)
                    {
                        break;
                    }
                    
                    Console.WriteLine("Введите значения для поиска:");
                    var searchValue = Console.ReadLine();
                    
                    if (numberAnswer - 1 >= 0 && numberAnswer - 1 < fields.Length)
                    {
                        // todo тут нужно сделать проверки чтобы можно было проверит тип
                        EmployeeBase.SelectSearchField(fields[numberAnswer - 1], searchValue);
                    }
                } while (true);
            }
            else if (numberAnswer == 2)
            {
                // Выбор отдела
            }


            // Отрисовка графа департамента и его сотрудников
            // Примеры: https://github.com/YaccConstructor/QuickGraph

            // var edges = new []
            // {
            //     new MyEdge(new MyVertex(staff[0]), new MyVertex(staff[1]))
            // };

            // todo Мой пример
            // var edges = new [] { new SEdge<int>(1,2), new SEdge<int>(0,1) };
            // var graph = edges.ToAdjacencyGraph<int, SEdge<int>>();
            // var algo = new GraphvizAlgorithm<int, SEdge<int>>(graph)
            // {
            //     ImageType = GraphvizImageType.Gd
            // };
            // var pathDot = PathHandler.GetGraphDotPath();
            // algo.Generate(new FileDotEngine(), pathDot);
            //
            // using(StreamReader readText = new StreamReader(pathDot))
            // {
            //     string graphVizString = readText.ReadToEnd();
            //     Bitmap bm = MyFileDotEngine.Run(graphVizString);
            //     bm.Save(PathHandler.GetPathImage("GraphImage"));
            // }
        }
    }
}