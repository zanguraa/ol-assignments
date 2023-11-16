using System.Reflection.Metadata;

namespace Classroom.ShapeHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5);
           var perimeterCircle = circle.CalculatePerimeter();
           var areaCircle = circle.CalculateArea();
            Rectangle rec = new Rectangle(4, 3);
            var rectPerimeter = rec.CalculatePerimeter();
            var rectArea = rec.CalculateArea();
            Triangle triangle = new Triangle(3, 4, 5);
            var trianglePerimeter = triangle.CalculatePerimeter();
            var triangleArea = triangle.CalculateArea();

            CalculateCircle(circle, areaCircle, perimeterCircle);
            Console.WriteLine();
            CalculateRectangle(rec, rectPerimeter, rectArea);
            Console.WriteLine();
            CalculateTriangle(triangle, triangleArea, trianglePerimeter);
        }

        static void CalculateCircle(Circle circle, double area, double perimeter)
        {
            Console.WriteLine($"Calculate with Radius: {circle.Radius}");
            Console.WriteLine($"Area: {area.ToString("0.00")}");
            Console.WriteLine($"Perimeter {perimeter.ToString("0.00")}");
        }
        static void CalculateRectangle(Rectangle rec, double perimeter, double area)
        {
            Console.WriteLine($"Rectangle with length {rec.Length} and width {rec.Width}");
            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Perimeter {perimeter}");
        }
        static void CalculateTriangle(Triangle triangle, double perimeter, double area)
        {
            Console.WriteLine($"Triangle widh sides {triangle.Side1}, {triangle.Side2}, {triangle.Side3} ");
            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Perimeter: {perimeter}");
        }
    }
}