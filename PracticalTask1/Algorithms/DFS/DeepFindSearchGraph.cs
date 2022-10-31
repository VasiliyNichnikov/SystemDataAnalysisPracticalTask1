using System;
using System.Collections.Generic;
using QuickGraph;

namespace PracticalTask1.Algorithms
{
    /// <summary>
    /// Алгоритмы работы с графом
    /// Один из алгоритмов: поиск в глубину - https://habr.com/ru/post/504374/
    /// </summary>
    public class DeepFindSearchGraph<T> where T : class
    {
        private struct Connection
        {
                public Vertex Preview { get; set; }
            public Vertex Current { get; set; }
            
            public override bool Equals(object obj)
            {
                if (obj is Connection otherConnection)
                {
                    return otherConnection.GetHashCode() == GetHashCode();
                }

                return false;
            }

            public override int GetHashCode()
            {
                return Preview.GetHashCode() + Current.GetHashCode();
            }
        }
        
        
        private readonly List<Connection> _cacheConnections = new();

        /// <summary>
        /// Получение вершин со всеми отделами
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Edge<string>> TranslateToEdgesForGraphWithDepartments(
            IReadOnlyList<DepartmentBase> departments)
        {
            _cacheConnections.Clear();

            return TranslateToEdgesForGraph(departments, new List<Edge<string>>());
        }

        /// <summary>
        /// Получаем сотрудника с привязанным к нему отделу
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="departments"></param>
        /// <returns></returns>
        public IReadOnlyList<Edge<Vertex>> TranslateToEdgesForGraphWithStartDepartment(
            INode<EmployeeBase> startNode,
            IReadOnlyList<DepartmentBase> departments)
        {
            _cacheConnections.Clear();
            
            var createdEdges = new List<Edge<Vertex>>();
            foreach (var department in departments)
            {
                if (startNode.Data.CheckDepartment(department))
                {
                    createdEdges.Add(new Edge<Vertex>(department.ConvertToVertex(), startNode.ConvertToVertex()));
                    break;
                }
            }
            
            return TranslateToEdgesForGraph(startNode as INode<T>, createdEdges);
        } 
        
        /// <summary>
        /// Представляем из текущей вершины граф
        /// </summary>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public IReadOnlyList<Edge<string>> TranslateToEdgesForGraphWithoutDepartments(
            INode<T> startNode)
        {
            _cacheConnections.Clear();

            return null;
            // todo нужно доработать
            // return TranslateToEdgesForGraph(startNode, new List<Edge<string>>());
        }
        
        // todo нужно доработать 
        private IReadOnlyList<Edge<string>> TranslateToEdgesForGraph(
            IReadOnlyList<DepartmentBase> departments,
            List<Edge<string>> createdEdges)
        {
            foreach (var department in departments)
            {
                var nameDepartmentCurrent = department.ToString();
                foreach (var employee in department.Staff)
                {
                    var nameEmployeeCurrent = employee.ToString();
                    createdEdges.Add(new Edge<string>(nameDepartmentCurrent, nameEmployeeCurrent));
                    // TranslateToEdgesForGraph(employee as INode<T>, createdEdges);
                }
            }

            return createdEdges;
        }
        
        private IReadOnlyList<Edge<Vertex>> TranslateToEdgesForGraph(
            INode<T> startNode, 
            List<Edge<Vertex>> createdEdges)
        {
            var nameEdgePreview = startNode.ConvertToVertex();
            foreach (var neighbor in startNode.Neighbors)
            {
                var nameEdgeCurrent = neighbor.ConvertToVertex();
                var connection = new Connection
                {
                    Preview = nameEdgePreview,
                    Current = nameEdgeCurrent
                };
                if (_cacheConnections.Contains(connection) == false)
                {
                    var newEdge = new Edge<Vertex>(nameEdgePreview, nameEdgeCurrent);
                    createdEdges.Add(newEdge);
                    _cacheConnections.Add(connection);
                }

                TranslateToEdgesForGraph(neighbor, createdEdges);
            }

            return createdEdges;
        }


        /// <summary>
        /// Возвращаем все найденные узлы
        /// Надо учитывать, что поиск должен начинаться от главной вершины 
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="matchesFound"></param>
        /// <param name="type">Тип с помощью которого будет осуществлятся поиск</param>
        /// <returns></returns>
        public IReadOnlyList<T> FoundAllNodes(
            INode<T> currentNode,
            List<T> matchesFound,
            TypeSearch type = TypeSearch.Equal)
        {
            if (currentNode.Visited)
            {
                return null;
            }

            if (currentNode.CheckVerbatim(type))
            {
                matchesFound.Add(currentNode.Data);
            }
            
            currentNode.Visited = true;
            foreach (var neighbor in currentNode.Neighbors)
            {
                if (neighbor.Visited == false)
                {
                    FoundAllNodes(neighbor, matchesFound, type);
                }
            }

            return matchesFound;
        }
    }
}