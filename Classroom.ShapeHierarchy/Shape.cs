using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.ShapeHierarchy
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override double CalculatePerimeter()
        {
            return 2 * Radius * Math.PI;
        }
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double CalculateArea()
        {
            return Width * Length;
        }
        public override double CalculatePerimeter()
        {
            return (Length + Width) * 2;
        }
    }
}
