using Microsoft.AspNetCore.Mvc;
using System;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        //Task_02
        public string Area(Triangle tr)
        {
            if (tr.Side1 > 0 && tr.Side2 > 0 && tr.Side3 > 0)
            {
                double halfPerimeter = (tr.Side1 + tr.Side2 + tr.Side3) / 2;
                double result = (Math.Sqrt(halfPerimeter * (halfPerimeter - tr.Side1)
                                              * (halfPerimeter - tr.Side2)
                                              * (halfPerimeter - tr.Side3)));
                return string.Format("{0:F4}", result);
            }
            else
                throw new ArgumentException();
        }
        //Task_05
        public bool IsEquilateral(double side1, double side2, double side3)
        {
            if ((side1 > 0 && side2 > 0 && side3 > 0))
            {
                return (side1 == side2 || side1 == side3 || side2 == side3);
            }
            else
                throw new ArgumentException();
        }
        //Task_07
        public bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            return (tr1.Side1 == tr2.Side1 && tr1.Side2 == tr2.Side2 && tr1.Side3 == tr2.Side3);
        }
        private bool isValid(double side1, double side2, double side3)
        {
            return (side1 + side2 >= side3
                 && side2 + side3 >= side1
                 && side1 + side3 >= side2
                     && side1 > 0 
                     && side2 > 0
                     && side3 > 0);
        }
    }
}
