using System;
using System.Collections.Generic;

namespace PracticalTask1.Algorithms
{
    /// <summary>
    /// Алгоритм быстрого поиска в графе
    /// https://habr.com/ru/post/504374/
    /// </summary>
    public class DeepFindSearchGraph<T> where T: class

    {
    /// <summary>
    /// Возвращаем все найденные узлы
    /// Надо учитывать, что поиск должен начинаться от главной вершины 
    /// </summary>
    /// <param name="currentNode"></param>
    /// <param name="visitedNode">Посдений просмотренный узел</param>
    /// <param name="matchesFound"></param>
    /// <returns></returns>
    public IReadOnlyList<T> FoundAllNodes(INode<T> currentNode, INode<T> visitedNode, List<T> matchesFound)
    {
        if (currentNode.CheckVerbatim())
        {
            matchesFound.Add(currentNode.Data);
        }

        if (visitedNode.Visited)
        {
            return null;
        }

        currentNode.Visited = true;
        foreach (var neighbor in currentNode.Neighbors)
        {
            if (!neighbor.Visited)
            {
                var reached = FoundAllNodes(neighbor, visitedNode, matchesFound);
                if (reached != null && reached.Count > 0)
                {
                    matchesFound.AddRange(reached);
                }
            }
        }

        return matchesFound;
    }
    }
}