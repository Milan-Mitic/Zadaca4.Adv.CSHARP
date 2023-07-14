namespace ZadacaClass4Adv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle() { Id = 1, Radius = 5 };

            Rectangle rectangle = new Rectangle() { Id = 2, SideA = 8, SideB = 10 };

            GenericDB<Shape> dB = new GenericDB<Shape>();

            dB.Add(circle);
            dB.Add(rectangle);

            Console.WriteLine("...................");

            dB.PrintAreas();
            dB.PrintPerimeters();

            Console.WriteLine("...................");

            circle.PrintInfo();
            Console.WriteLine("...................");
            rectangle.PrintInfo();
        }
    }

    public class Shape
    {
        public int Id { get; set; }

        public virtual double GetArea()
        {
            return 0;
        }
        public virtual double GetPerimeter()
        {
            return 0;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double SideA { get; set; }

        public double SideB { get; set; }

        public override double GetArea()
        {
            return SideA * SideB;
        }

        public override double GetPerimeter()
        {
            return 2 * (SideA + SideB);
        }
    }

    public class GenericDB<T> where T : Shape
    {
        public List<T> shapes;

        public GenericDB()
        {
            shapes = new List<T>();
        }
        public void Add(T shape)
        {
            shapes.Add(shape);
        }
        public void PrintAreas()
        {
            foreach (T shape in shapes)
            {
                Console.WriteLine($"Shape ID: {shape.Id}, Area: {shape.GetArea()}");
            }
        }
        public void PrintPerimeters()
        {
            foreach (T shape in shapes)
            {
                Console.WriteLine($"Shape ID: {shape.Id}, Perimeter: {shape.GetPerimeter()}");
            }
        }
    }

    public static class ShapeExtensions
    {
        public static void PrintInfo(this Circle circle)
        {
            Console.WriteLine("Circle: ");
            Console.WriteLine($"Radius of circle: {circle.Radius} ");
            Console.WriteLine($"Area of circle: {circle.GetArea()}");
            Console.WriteLine($"Perimeter of circle: {circle.GetPerimeter()}");
        }

        public static void PrintInfo(this Rectangle rectangle)
        {
            Console.WriteLine("Rectangle: ");
            Console.WriteLine($"SideA: {rectangle.SideA} \nSideB: {rectangle.SideB}");
            Console.WriteLine($"Area of rectangle: {rectangle.GetArea()}");
            Console.WriteLine($"Perimeter of rectangle: {rectangle.GetPerimeter()}");
        }
    }
}