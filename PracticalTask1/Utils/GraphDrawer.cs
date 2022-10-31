using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using PracticalTask1.Algorithms;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace PracticalTask1.Utils
{
    public class GraphDrawer
    {
        private readonly DeepFindSearchGraph<EmployeeBase> _dfsEmployee;
        private readonly IReadOnlyList<DepartmentBase> _departments;
        private readonly IReadOnlyList<EmployeeBase> _staff;

        public GraphDrawer(IReadOnlyList<EmployeeBase> staff, IReadOnlyList<DepartmentBase> departments)
        {
            _dfsEmployee = new DeepFindSearchGraph<EmployeeBase>();
            _staff = staff;
            _departments = departments;
            // var edges = dfsEmployee.TranslateToEdgesForGraphWithDepartments(departments as IReadOnlyList<DepartmentBase>);
        }

        public void Draw(TypeSearch type)
        {
            // todo тут проблема, что у нас обязательно 4 элемент должен быть главным в графе
            
            // todo имеено тут работники лишаются отдела
            var nodes = _dfsEmployee.FoundAllNodes(_staff[4],new List<EmployeeBase>(), type);

            var edges = new List<Edge<Vertex>>();

            Console.WriteLine("Found users:");
            foreach (var node in nodes)
            {
                Console.WriteLine($"Name: {node.Name}. Type: {node.GetType()}");
                
                var elements = _dfsEmployee.TranslateToEdgesForGraphWithStartDepartment(node, _departments);
                edges.AddRange(elements);
            }
            
            var graph = edges.ToAdjacencyGraph<Vertex, Edge<Vertex>>();
            var algo = new GraphvizAlgorithm<Vertex, Edge<Vertex>>(graph)
            {
                ImageType = GraphvizImageType.Gd2
            };
            algo.FormatVertex += (sender, eventArgs) =>
            {
                var selectedVertex = eventArgs.Vertex;
                eventArgs.VertexFormatter.Label = selectedVertex.Name;
                eventArgs.VertexFormatter.StrokeColor = selectedVertex.StrokeColor;
            };
            
            var pathDot = PathHandler.GetGraphDotPath();
            algo.Generate(new FileDotEngine(), pathDot);
            
            // Сохранение в Png
            using(StreamReader readText = new StreamReader(pathDot))
            {
                string graphVizString = readText.ReadToEnd();
                Bitmap bm = MyFileDotEngine.Run(graphVizString);
                bm.Save(PathHandler.GetPathImage("GraphImage"));
            }
        }
        
    }
}