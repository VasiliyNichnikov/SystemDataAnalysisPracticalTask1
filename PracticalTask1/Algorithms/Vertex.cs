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

        public override bool Equals(object obj)
        {
            if (obj is Vertex v)
            {
                return GetHashCode() == obj.GetHashCode();
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}