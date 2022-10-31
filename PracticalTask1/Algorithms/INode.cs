using System.Collections.Generic;

namespace PracticalTask1.Algorithms
{
    public interface INode<out T> where T: class
    {
        T Data { get; }
        bool Visited { get; set; }
        bool Excluded { get; set; }
        IReadOnlyList<INode<T>> Neighbors { get; }
        bool CheckVerbatim(TypeSearch type);
        Vertex ConvertToVertex();
    }
}