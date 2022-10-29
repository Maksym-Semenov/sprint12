using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Triangles.Models;
using Triangles.Services;
using System.Text;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        public double Perimeter(Triangle triangle)
        {
            return TriangleService.Perimeter(triangle);
        }
        /*public bool IsIsosceles(Triangle triangle)
        {
            if (Triangle.IsValid(triangle))
            {
                return (TriangleService.AreTwoDoublesEqual(triangle.Side1, triangle.Side2)
                        || TriangleService.AreTwoDoublesEqual(triangle.Side1, triangle.Side3)
                        || TriangleService.AreTwoDoublesEqual(triangle.Side2, triangle.Side3));
            }
            else
                return false;
        }

        public bool IsRightAngled(Triangle triangle)
        {
            if (IsValid(triangle))
            {
                double[] arrayOFTriangleSides = new Double[3] { triangle.Side1, triangle.Side2, triangle.Side3 };
                Array.Sort(arrayOFTriangleSides);
                double hypotenuse = arrayOFTriangleSides[2],
                    leg1 = arrayOFTriangleSides[1],
                    leg2 = arrayOFTriangleSides[0];
                return (IsEqualDouble(Math.Pow(hypotenuse, 2), (Math.Pow(leg1, 2) + Math.Pow(leg2, 2))));
            }
            else
                return false;
        }*/

        /*public string NumbersPairwiseNotSimilar(Triangle[] triangles)
        {
            StringBuilder resultString = new StringBuilder();
            int i = 0, j = 0;
            while (i < triangles.Length)
            {
                while (j < triangles.Length)
                {
                    if (!AreSimilar(triangles[i], triangles[j]))
                    {
                        resultString.Append($"({i + 1}, {j + 1})\r\n");
                    }

                    j++;
                }

                i++;
                j = i;
            }
            return resultString.ToString().TrimEnd();
        }*/
        public double Area(Triangle tr)
        {
            return TriangleService.Area(tr);
        }
        public bool IsEquilateral(Triangle tr)
        {
            return TriangleService.IsEquilateral(tr);
        }
        public bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            return TriangleService.AreCongruent(tr1, tr2);
        }
        public bool AreSimilar(Triangle tr1, Triangle tr2)
        {
            return TriangleService.AreSimilar(tr1, tr2);
        }
        public string Info(Triangle tr)
        {
            return TriangleService.Info(tr);
        }
        public string InfoGreatestPerimeter(Triangle[] triangles)
        {
            return TriangleService.InfoGreatestPerimeter(triangles);
        }
        public string InfoGreatestArea(Triangle[] triangles)
        {
            return TriangleService.InfoGreatestArea(triangles);
        }
    }
}