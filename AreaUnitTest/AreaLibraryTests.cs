using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;



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

        [TestMethod]
        public void TestCircleCaseCorrect()
        {
            double result = pi * r * r;
            double fromLibrary = AreaLibrary.AreaCalculator.Circle(r);
            Assert.AreEqual(fromLibrary, result, 0.01, "From library = " + fromLibrary + " should be = " + result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Radius should be positive")]
        public void TestCircleCaseZero()
        {            
            double fromLibrary = AreaLibrary.AreaCalculator.Circle(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Radius should be positive")]
        public void TestCircleCaseNegative()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Circle(-r);            
        }

        [TestMethod]
        public void TestTriangleThreeSidesCaseCorrect()
        {
            double result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(a, b, c);
            Assert.AreEqual(fromLibrary, result, 0.01, "Results are equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides should be positive")]
        public void TestTriangleThreeSidesCaseNegative()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(-a, b, c);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides should be positive")]
        public void TestTriangleThreeSidesCaseZero()
        {
            
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(a, 0, c);
        }

        [TestMethod]
        public void TestTriangleBaseAndHeightCorrectCase()
        {
            double result = 0.5 * b * h;
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(b, h);
            Assert.AreEqual(fromLibrary, result, 0.01, "Results are equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive")]
        public void TestTriangleBaseAndHeightCaseZeroBase()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(0, h);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive")]
        public void TestTriangleBaseAndHeightCaseZeroHeight()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(b, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive")]
        public void TestTriangleBaseAndHeightCaseZeroBaseAndHeight()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Triangle(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive")]
        public void TestTriangleBaseAndHeightCaseNegativeBase()
        {
            double area = AreaLibrary.AreaCalculator.Triangle(-b, h);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive")]
        public void TestTriangleBaseAndHeightCaseNegativeHeight()
        {
            double area = AreaLibrary.AreaCalculator.Triangle(b, -h);  
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Base and height should be positive")]
        public void TestTriangleBaseAndHeightCaseNegativeBaseAndHeight()
        {
            double area = AreaLibrary.AreaCalculator.Triangle(-b, -h);
        }

        [TestMethod]
        public void TestTrapezoidCorrectCase()
        {
            double result = 0.5 * (b + c) * h;
            double fromLibrary = AreaLibrary.AreaCalculator.Trapezoid(b, c, h);
            Assert.AreEqual(fromLibrary, result, 0.01, "Results are equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides and height should be positive")]
        public void TestTrapezoidCaseZeroBase()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Trapezoid(0, c, h);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides and height should be positive")]
        public void TestTrapezoidCaseZeroHeight()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Trapezoid(b, c, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides and height should be positive")]
        public void TestTrapezoidCaseZeroBaseAndHeight()
        {
            double fromLibrary = AreaLibrary.AreaCalculator.Trapezoid(0, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides and height should be positive")]
        public void TestTrapezoidCaseNegativeBase()
        {
            double area = AreaLibrary.AreaCalculator.Trapezoid(-b, c, h);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides and height should be positive")]
        public void TestTrapezoidCaseNegativeHeight()
        {
            double area = AreaLibrary.AreaCalculator.Trapezoid(b, c, -h);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Sides and height should be positive")]
        public void TestTrapezoidCaseNegativeBaseAndHeight()
        {
            double area = AreaLibrary.AreaCalculator.Trapezoid(-b, -c, -h);
        }

        [TestMethod]
        public void TestIsRightTriangleTrue()
        {
            bool fromLibrary = AreaLibrary.AreaCalculator.isRightTriangle(3, 4, 5);
            Assert.IsTrue(fromLibrary);
        }

        [TestMethod]
        public void TestIsRightTriangleFalse()
        {            
            bool fromLibrary = AreaLibrary.AreaCalculator.isRightTriangle(a, b, c);
            Assert.IsFalse(fromLibrary);
        }
    }
}
