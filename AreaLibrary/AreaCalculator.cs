using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaLibrary
{
    /// <summary>
    /// Сlass containing methods for calculating the area and obtaining additional information about shapes.
    /// </summary>
    public class AreaCalculator
    {        
        /// <summary>
        /// Calculate area of circles     
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        /// <returns>Area of circles</returns>
        public static double Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius should be positive");
            }
            return Math.PI * Math.Pow(radius, 2);
        }

        /// <summary>
        /// Calculate area of triangles
        /// </summary>
        /// <param name="a">Side \"a\"</param>
        /// <param name="b">Side \"b\"</param>
        /// <param name="c">Side \"c\"</param>
        /// <returns>Area of the triangle</returns>
        //Area of triangles
        public static double Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive");
            }
            double p = (a + b + c) / 2;
            if (p < a || p < b || p < c)
            {
                throw new ArgumentException("Half of the perimeter should be more than any side of triangle");
            }
            return Math.Pow((p * (p - a) * (p - b) * (p - c)), 0.5);
        }

        /// <summary>
        /// Calculate area of triangles
        /// </summary>
        /// <param name="b">Base of the triangle</param>
        /// <param name="height">Height of the triangle</param>
        /// <returns>Area of the triangle</returns>
        public static double Triangle(double b, double height)
        {
            if (b <= 0 || height <= 0)
            {
                throw new ArgumentException("Base and height should be positive");
            }

            return 0.5 * b * height;
        }

        /// <summary>
        /// Calculate area of parallelograms(it includes squares and rectangles).
        /// </summary>
        /// <param name="b">Base of the parallelogram</param>
        /// <param name="height">Height of the parallelogram</param>
        /// <returns>Area of the parallelogramm</returns>
        public static double Parallelogram(double b, double height)
        {
            return 2 * Triangle(b, height);
        }

        /// <summary>
        /// Calculate area of trapezoids.
        /// </summary>
        /// <param name="b">Base of the trapezoid</param>
        /// <param name="c">Side parallel to the base of the trapezoid</param>
        /// <param name="height">Height of the trapezoid</param>
        /// <returns>Area of the trapezoid</returns>
        public static double Trapezoid(double b, double c, double height)
        {
            if (height <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides and height should be positive");
            }
            return Triangle(b + c, height);
        }

        /// <summary>
        /// Find out if the triangle is right
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public static bool isRightTriangle(double a, double b, double c)
        {
            
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive");
            }
            double maxSide = Math.Max(Math.Max(a, b), c);
            return (maxSide * maxSide) == (maxSide == a ? b * b + c * c :
                                            maxSide == b ? a * a + c * c :
                                            a * a + b * b);
        }
    }
}
