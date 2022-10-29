using System;
using Triangles.Models;

namespace Triangles.Services
{
    public class TriangleService
    {
        public static double Perimeter(Triangle triangle)
        {
            if (Triangle.IsValid(triangle))
                return (triangle.Side1 + triangle.Side2 + triangle.Side3);
            else
                return 0;
        }
        public static bool AreTwoDoublesEqual(double db1, double db2)
        {
            return Math.Abs(db1 - db2) <= db1 * 1e-5;
        }
    }
}