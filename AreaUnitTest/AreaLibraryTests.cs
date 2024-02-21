using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaLibrary;
using System.Collections.Generic;

namespace AreaUnitTest
{
    [TestClass]
    public class AreaLibraryTests
    {
        public const double a = 3.54; 
        public const double b = 3.54;
        public const double c = 3.54;
        public const double p = (a + b + c) / 2;
        public const double h = 3.54;
        public const double r = 3.54;
        public const double pi = Math.PI;
        public Point A = new Point(0, 0);
        public Point B = new Point(1, 1);
        public Point C = new Point(2, 1);
        public Point D = new Point(1, 0);
        public Point E = new Point(1, -1);
        public Point F = new Point(0, 0);

        [TestMethod]
        public void TestDistanceCaseCorrect()
        {
            A.CalculateDistance(B);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The point must not be null.")]
        public void TestDistanceCaseNull()
        {
            A.CalculateDistance(null);
        }

        [TestMethod]
        public void TestPolygonCaseVerticeCorrect()
        {
            List<Point> vertices = new List<Point>();
            vertices.Add(A);
            vertices.Add(B);
            vertices.Add(C);
            vertices.Add(D);
            vertices.Add(E);
            Polygon polygon = new Polygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The list of vertices cannot be null.")]
        public void TestPolygonCaseListNull()
        {
            List<Point> vertices = null;
            Polygon polygon = new Polygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The list of vertices must not contain null elements.")]
        public void TestPolygonCaseVerticeNull()
        {
            List<Point> vertices = new List<Point>();
            vertices.Add(A);
            vertices.Add(null);
            vertices.Add(C);
            Polygon polygon = new Polygon(vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The figure must not contain matching vertices.")]
        public void TestPolygonCaseDuplicates()
        {
            List<Point> vertices = new List<Point>();
            vertices.Add(A);
            vertices.Add(F);
            vertices.Add(C);
            Polygon polygon = new Polygon(vertices);
        }

        [TestMethod]
        public void TestCircleCaseRadiusCorrect()
        {
            double result = pi * r * r;
            Circle circle = new Circle(r);
            double fromLibrary = circle.CalculateArea();
            Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Radius should be positive.")]
        public void TestCircleCaseRadiusZeroOrNegative()
        {
            Circle circle = new Circle(-r);
            double fromLibrary = circle.CalculateArea();
        }

        [TestMethod]
        public void TestCircleCaseCenterCorrect()
        {
            double result = pi * Math.Pow(A.CalculateDistance(D), 2);
            Circle circle = new Circle(A, D);
            double fromLibrary = circle.CalculateArea();
            Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Points must not be null.")]
        public void TestCircleCaseCenterNull()
        {
            Circle circle = new Circle(null, D);
            double fromLibrary = circle.CalculateArea();
        }

        [TestMethod]
        public void TestCircleCasePointsCorrect()
        {
            List<Point> vertices = new List<Point>();
            vertices.Add(A);
            vertices.Add(B);
            vertices.Add(C);
            Triangle triangle = new Triangle(vertices);
            double result = pi * Math.Pow(A.CalculateDistance(B) * C.CalculateDistance(B)
                * A.CalculateDistance(C) / triangle.CalculateArea(), 2);
            Circle circle = new Circle(A, B, C);
            double fromLibrary = circle.CalculateArea();
            Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Points must not be null.")]
        public void TestCircleCasePointsNull()
        {
            Circle circle = new Circle(null, B, C);
            double fromLibrary = circle.CalculateArea();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid number of vertices.")]
        public void TestTriangleThreeVerticesCaseFourVertices()
        {
            List<Point> vertices = new List<Point>();
            vertices.Add(A);
            vertices.Add(B);
            vertices.Add(C);
            vertices.Add(D);
            Triangle triangle = new Triangle(vertices);
        }

        [TestMethod]
        public void TestTriangleThreeSidesCaseCorrect()
        {
            Triangle triangle = new Triangle(a, b, c);
            double result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double fromLibrary = triangle.CalculateArea();
            Assert.AreEqual(fromLibrary, result, 0.01, "Results are equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides should be positive.")]
        public void TestTriangleThreeSidesCaseZeroOrNegative()
        {
            Triangle triangle = new Triangle(-a, b, c);
            double result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double fromLibrary = triangle.CalculateArea();
        }

        [TestMethod]
        public void TestTriangleBaseAndHeightCaseCorrect()
        {
            Triangle triangle = new Triangle(a, h);
            double result = 0.5 * a * h;
            double fromLibrary = triangle.CalculateArea(); 
            Assert.AreEqual(fromLibrary, result, 0.01, "Results are equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive.")]
        public void TestTriangleBaseAndHeightCaseZeroOrNegative()
        {
            Triangle triangle = new Triangle(-a, h);
            double fromLibrary = triangle.CalculateArea();
        }
    }
}
