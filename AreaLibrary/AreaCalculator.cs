using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaLibrary
{
    public interface IFigure
    {
        /// <summary>
        /// Calculate area of the figure.   
        /// </summary>
        double CalculateArea();
    }

    /// <summary>
    /// Class to create points with given coordinates on X and Y axes.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Point's coordinate on X axis.
        /// </summary>
        public double X { get; }
        /// <summary>
        /// Point's coordinate on Y axis.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Circle constructor.
        /// </summary>
        /// <param name="x">Coordinate on X axis</param>
        /// <param name="y">Coordinate on Y axis</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calculate distance.
        /// </summary>
        /// <returns>Distance between these points.</returns>
        public double CalculateDistance(Point point)
        {
            if (point == null)
            {
                throw new ArgumentException("The point must not be null.");
            }
            return Math.Sqrt(Math.Pow(this.X - point.X, 2) + Math.Pow(this.Y - point.Y, 2));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Point other = (Point)obj;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X.GetHashCode(), Y.GetHashCode());
        }
    }

    /// <summary>
    /// Class to create polygons with vertices' coordinates.
    /// </summary>
    public class Polygon : IFigure
    {
        /// <summary>
        /// Polygon's vertices.
        /// </summary>
        public List<Point> Vertices { get; }

        /// <summary>
        /// Polygon constructor.
        /// </summary>
        /// <param name="vertices">Polygon's vertices coordinates</param>
        public Polygon(List<Point> vertices)
        {
            if(vertices == null)
            {
                throw new ArgumentNullException(nameof(vertices), "The list of vertices cannot be null.");
            }
            else if (vertices.Contains(null))
            {
                throw new ArgumentException("The list of vertices must not contain null elements.");
            }
            else if (HasDuplicateVertices(vertices))
            {
                throw new ArgumentException("The figure must not contain matching vertices.");
            }
            Vertices = vertices;
        }

        /// <summary>
        /// Polygon constructor.
        /// </summary>
        public Polygon()
        {
        }

        /// <summary>
        /// Calculate area of the polygon.
        /// </summary>
        /// <returns>Area of the polygon.</returns>
        public double CalculateArea()
        {
            if (Vertices == null || Vertices.Count < 3)
            {
                throw new ArgumentException("Invalid number of vertices for a polygon.");
            }

            int n = Vertices.Count;

            // Using the Gaussian area formula for a polygon
            double area = 0;

            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                area += Vertices[i].X * Vertices[j].Y - Vertices[j].X * Vertices[i].Y;
            }

            area /= 2;
            return Math.Abs(area);
        }
                
        /// <summary>
        /// Check vertices for duplicates.
        /// </summary>
        private static bool HasDuplicateVertices(List<Point> vertices)
        {
            HashSet<Point> uniqueVertices = new HashSet<Point>(vertices);
            return uniqueVertices.Count < vertices.Count;
        }
    }

    /// <summary>
    /// Class to create circles with a given radius.
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Circle's radius.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Circle constructor based on given radius.
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentException("Radius should be positive.");
            }
            Radius = radius;
        }

        /// <summary>
        /// Сircle constructor based on the center and point on the circle.
        /// </summary>
        /// <param name="center">Center of the circle</param>
        /// <param name="point">Point on the circle</param>
        public Circle(Point center, Point point)
        {
            if(center == null || point == null)
            {
                throw new ArgumentException("Points must not be null.");
            }
            Radius = Math.Sqrt(Math.Pow(center.X - point.X, 2) + Math.Pow(center.Y - point.Y, 2));           
        }

        /// <summary>
        /// Сircle constructor based on three points on the circle.
        /// </summary>
        /// <param name="pointA">Point \"A\" on the circle</param>
        /// <param name="pointB">Point \"B\" on the circle</param>
        /// <param name="pointC">Point \"C\" on the circle</param>
        public Circle(Point pointA, Point pointB, Point pointC)
        {
            if (pointA == null || pointB == null || pointC == null)
            {
                throw new ArgumentException("Points must not be null.");
            }
            List<Point> vertices = new List<Point>();
            vertices.Add(pointA);
            vertices.Add(pointB);
            vertices.Add(pointC);
            Triangle triangle = new Triangle(vertices);
            Radius = pointA.CalculateDistance(pointB) * pointC.CalculateDistance(pointB) 
                * pointA.CalculateDistance(pointC) / triangle.CalculateArea();
        }

        /// <summary>
        /// Calculate area of the circle.   
        /// </summary>
        /// <returns>Area of the circle.</returns>
        public double CalculateArea()
        {
            if(Radius <= 0)
            {
                throw new ArgumentException("Radius should be positive.");
            }
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    /// <summary>
    /// Class to create triangles with given sides or base and height.
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// 1st side of the triangle.
        /// </summary>
        public double Side1 { get; }
        /// <summary>
        /// 2nd side of the triangle.
        /// </summary>
        public double Side2 { get; }
        /// <summary>
        /// 3rd side of the triangle.
        /// </summary>
        public double Side3 { get; }
        /// <summary>
        /// Height of the triangle.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Triangle constructor based on given sides.
        /// </summary>
        /// <param name="vertices">Triangle's vertices coordinates</param>
        public Triangle(List<Point> vertices) : base(vertices)
        {
            if(vertices.Count != 3)
            {
                throw new ArgumentException("Invalid number of vertices.");
            }
        }

        /// <summary>
        /// Triangle constructor based on given sides.
        /// </summary>
        /// <param name="side1">Side 1</param>
        /// <param name="side2">Side 2</param>
        /// <param name="side3">Side 3</param>
        public Triangle(double side1, double side2, double side3)
        {
            if (Side1 <= 0 || Side2 <= 0 || Side3 <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        /// <summary>
        /// Triangle constructor based on given base and height.
        /// </summary>
        /// <param name="base">Base</param>
        /// <param name="height">Height</param>       
        public Triangle(double @base, double height)
        {
            if (@base <= 0 || height <= 0)
            {
                throw new ArgumentException("Base and height should be positive.");
            }
            Side1 = @base;
            Height = height;
        }

        /// <summary>
        /// Calculate area of the triangle.   
        /// </summary>
        /// <returns>Area of the triangle.</returns>
        public new double CalculateArea()
        {
            if(Vertices != null && Vertices.Count == 3)
            {
                base.CalculateArea();
            }
            else if (Side1 <= 0)
            {
                if (Side2 <= 0 || Side3 <= 0)
                {
                    throw new ArgumentException("Sides should be positive.");
                }
                else if(Height <= 0)
                {
                    throw new ArgumentException("Base and height should be positive.");
                }                
            }

            if (Height > 0)
            {
                return 0.5 * Side1 * Height;
            }

            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        /// <summary>
        /// Find out if the triangle is right
        /// </summary>
        public bool IsRightTriangle()
        {
            double[] sides = { Side1, Side2, Side3 };
            Array.Sort(sides);
            return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
        }
    }

    /// <summary>
    /// Class to create trapezoids with given bases and height.
    /// </summary>
    public class Trapezoid : Polygon
    {
        /// <summary>
        /// 1st base of the trapezoid.
        /// </summary>
        public double Base1 { get; }
        /// <summary>
        /// 2nd base of the trapezoid.
        /// </summary>
        public double Base2 { get; }
        /// <summary>
        /// Height of the trapezoid.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Trapezoid constructor.
        /// </summary>
        /// <param name="base1">Base 1</param>
        /// <param name="base2">Base 2</param>
        /// <param name="height">Height</param>
        public Trapezoid(double base1, double base2, double height)
        {
            if (base1 <= 0 || base2 <= 0 || height <= 0)
            {
                throw new ArgumentException("Bases and height should be positive.");
            }
            Base1 = base1;
            Base2 = base2;
            Height = height;
        }

        /// <summary>
        /// Calculate area of the trapezoid.
        /// </summary>
        /// <returns>Area of the trapezoid.</returns>
        public new double CalculateArea()
        {
            if (Vertices != null && Vertices.Count == 4)
            {
                base.CalculateArea();
            }
            else if (Base1 <= 0 || Base2 <= 0 || Height <= 0)
            {
                throw new ArgumentException("Bases and height should be positive.");
            }
            return 0.5 * Base1 * Base2 * Height;
        }
    }

    /// <summary>
    /// Class to create parallelogram with given base and height.
    /// </summary>
    public class Parallelogram : Polygon
    {
        /// <summary>
        /// Base of the parallelogram.
        /// </summary>
        public double Base { get; }
        /// <summary>
        /// Height of the parallelogram.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Trapezoid constructor.
        /// </summary>
        /// <param name="base">Base 1</param>
        /// <param name="height">Height</param>
        public Parallelogram(double @base, double height)
        {
            if (@base <= 0|| height <= 0)
            {
                throw new ArgumentException("Base and height should be positive.");
            }
            Base = @base;
            Height = height;
        }

        /// <summary>
        /// Calculate area of the parallelogram.
        /// </summary>
        /// <returns>Area of the parallelogram.</returns>
        public new double CalculateArea()
        {
            if (Vertices != null && Vertices.Count == 4)
            {
                base.CalculateArea();
            }
            else if (Base <= 0 || Height <= 0)
            {
                throw new ArgumentException("Base and height should be positive.");
            }
            return Base * Height;
        }
    }

    /// <summary>
    /// Сlass for calculating the area and obtaining additional information about shapes.
    /// </summary>
    public class ShapeCalculator
    {
        public double CalculateArea(IFigure figure)
        {
            if (figure == null)
            {
                throw new ArgumentNullException(nameof(figure));
            }

            return figure.CalculateArea();
        }
    }    
}