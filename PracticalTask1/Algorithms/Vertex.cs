using System.Drawing;

namespace PracticalTask1.Algorithms
{
    public class Vertex
    {
        public string Name { get; }
        public Color StrokeColor { get; }

        public Vertex(string name, Color strokeColor)
        {
            StrokeColor = strokeColor;
            Name = name;
        }
    }
}