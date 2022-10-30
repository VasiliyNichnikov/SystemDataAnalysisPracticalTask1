using System.Collections.Generic;

namespace PracticalTask1.Algorithms
{
    public interface INode<T>
    {
        T Data { get; }
        bool Visited { get; set; }
        IReadOnlyList<INode<T>> Neighbors { get; }
        bool CheckVerbatim();
    }
}