using Microsoft.AspNetCore.Mvc;
using System;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        public decimal Area(double side1, double side2, double side3)
        {
            if (side1 > 0 && side2 > 0 && side3 > 0)
            {
                double halfPerimeter = Perimeter(side1, side2, side3) / 2;
                double result = Math.Round(Math.Sqrt(halfPerimeter * (halfPerimeter - side1)
                                              * (halfPerimeter - side2)
                                              * (halfPerimeter - side3)), 4);
                return (decimal)result;
            }
            else
                throw new ArgumentException();
        }
    }
}
