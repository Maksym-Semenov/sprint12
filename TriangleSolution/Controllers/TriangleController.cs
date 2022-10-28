using System;
using Microsoft.AspNetCore.Mvc;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        public string Perimeter(Triangle triangle)
        {
            return (triangle.Side1 + triangle.Side2 + triangle.Side3).ToString();
        }
        public bool IsIsosceles(Triangle triangle)
        {
            if (IsValid(triangle))
            {
                return (IsEqualDouble(triangle.Side1, triangle.Side2) || IsEqualDouble(triangle.Side1, triangle.Side3) || IsEqualDouble(triangle.Side2, triangle.Side3));
            }
            else
                return false;
        }

        public bool IsRightAngled(Triangle triangle)
        {
            if (IsValid(triangle))
            {
                double[] arrayOFTrianglesSides = new Double[3];
                Array
            }
            else
                return false;
        }
        private bool IsValid(double side1, double side2, double side3)
        {
            return (side1 + side2 >= side3
                    && side2 + side3 >= side1
                    && side1 + side3 >= side2
                    && side1 > 0 
                    && side2 > 0
                    && side3 > 0);
        }
        
        private bool IsValid(Triangle tr)
        {
            return (tr.Side1 + tr.Side2 >= tr.Side3
                    && tr.Side2 + tr.Side3 >= tr.Side1
                    && tr.Side1 + tr.Side3 >= tr.Side2
                    && tr.Side1 > 0
                    && tr.Side2 > 0
                    && tr.Side3 > 0);
        }
        private bool IsEqualDouble(double db1, double db2)
        {
            return Math.Abs(db1 - db2) <= db1 * 1e-5;
        }
    }
}
