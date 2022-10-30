using QuikGraph;

namespace PracticalTask1.Utils
{
    public class MyVertex
    {
        public MyVertex(EmployeeBase employee)
        {
            
        }
    }
    public class MyEdge: Edge<MyVertex>
    {
        public MyEdge(MyVertex source, MyVertex target) : base(source, target)
        {
        }
    }

    public class MyGraph : AdjacencyGraph<MyVertex, MyEdge>{}
}