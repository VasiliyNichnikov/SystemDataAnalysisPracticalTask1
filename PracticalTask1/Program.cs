using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PracticalTask1.Algorithms;
using PracticalTask1.Utils;
using QuickGraph;
using QuickGraph.Algorithms.Search;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace PracticalTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = TranslationToObjectsFromJson.Departments as IReadOnlyList<DepartmentBase>;
            var staff = TranslationToObjectsFromJson.Staff as IReadOnlyList<EmployeeBase>;

            var dfsEmployee = new DeepFindSearchGraph<EmployeeBase>();
            
            EmployeeBase.SelectSearchField("_name", "Дарья");
            
            var nodes = dfsEmployee.FoundAllNodes(staff[4],new List<EmployeeBase>(), TypeSearch.Equal);
            
            Console.WriteLine();
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

            Console.WriteLine();

            // todo вершины выбранного пользователя
            var edges = dfsEmployee.TranslateToEdgesForGraphWithStartDepartment(staff[4], departments);

            // var edges = dfsEmployee.TranslateToEdgesForGraphWithDepartments(departments as IReadOnlyList<DepartmentBase>);
            
            var graph = edges.ToAdjacencyGraph<Vertex, Edge<Vertex>>();
            var algo = new GraphvizAlgorithm<Vertex, Edge<Vertex>>(graph)
            {
                ImageType = GraphvizImageType.Gd2
            };
            algo.FormatVertex += (sender, eventArgs) =>
            {
                if (eventArgs.Vertex is Vertex v)
                {
                    eventArgs.VertexFormatter.Label = v.Name;
                    eventArgs.VertexFormatter.StrokeColor = v.StrokeColor;
                }
            };
            
            var pathDot = PathHandler.GetGraphDotPath();
            algo.Generate(new FileDotEngine(), pathDot);
            
            // Сохранение в Png
            // using(StreamReader readText = new StreamReader(pathDot))
            // {
            //     string graphVizString = readText.ReadToEnd();
            //     Bitmap bm = MyFileDotEngine.Run(graphVizString);
            //     bm.Save(PathHandler.GetPathImage("GraphImage"));
            // }
        }
    }
}