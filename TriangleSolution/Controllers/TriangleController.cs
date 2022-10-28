using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Triangles.Models;
using System.Text;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        //Моє
        public double Perimeter(Triangle triangle)
        {
            return (triangle.Side1 + triangle.Side2 + triangle.Side3);
        }
        public bool IsIsosceles(Triangle triangle)
        {
            if (IsValid(triangle))
            {
                return (IsEqualDouble(triangle.Side1, triangle.Side2) 
                        || IsEqualDouble(triangle.Side1, triangle.Side3) 
                        || IsEqualDouble(triangle.Side2, triangle.Side3));
            }
            else
                return false;
        }
        public bool IsRightAngled(Triangle triangle)
        {
            if (IsValid(triangle))
            {
                double[] arrayOFTriangleSides = new Double[3]{ triangle.Side1, triangle.Side2, triangle.Side3};
                Array.Sort(arrayOFTriangleSides);
                double hypotenuse = arrayOFTriangleSides[2],
                    leg1 = arrayOFTriangleSides[1],
                    leg2 = arrayOFTriangleSides[0];
                return (IsEqualDouble(Math.Pow(hypotenuse, 2), (Math.Pow(leg1, 2) + Math.Pow(leg2, 2))));
            }
            else
                return false;
        }
        public string NumbersPairwiseNotSimilar(Triangle[] triangles)
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
            string result = resultString.ToString();
            return  result.TrimEnd();
        }
        //Інших
        public double Area(Triangle tr)
        {
            if (IsValid(tr))
            {
                double halfPerimeter = (tr.Side1 + tr.Side2 + tr.Side3) / 2;
                double area = (Math.Sqrt(halfPerimeter * (halfPerimeter - tr.Side1)
                                                       * (halfPerimeter - tr.Side2)
                                                       * (halfPerimeter - tr.Side3)));
                return area;
            }
            else
                return 0;
        }
        public bool IsEquilateral(Triangle tr)
        {
            if (IsValid(tr))
            {
                return (IsEqualDouble(tr.Side1, tr.Side2)
                        && IsEqualDouble(tr.Side1, tr.Side3)
                        && IsEqualDouble(tr.Side2, tr.Side3));
            }
            else
                return false;
        }
        public bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            if(IsValid(tr1) && IsValid(tr2))
            {
                double[] arrayOFTriangle1Sides = new Double[3]{ tr1.Side1, tr1.Side2, tr1.Side3};
                double[] arrayOFTriangl21Sides = new Double[3]{ tr2.Side1, tr2.Side2, tr2.Side3};
                Array.Sort(arrayOFTriangle1Sides);
                Array.Sort(arrayOFTriangl21Sides);
                return (IsEqualDouble(arrayOFTriangle1Sides[0], arrayOFTriangl21Sides[0]) 
                        && IsEqualDouble(arrayOFTriangle1Sides[1], arrayOFTriangl21Sides[1]) 
                        && IsEqualDouble(arrayOFTriangle1Sides[2], arrayOFTriangl21Sides[2]));
            }
            else
                return false;
        }
        public bool AreSimilar(Triangle tr1, Triangle tr2)
        {
            double[] sides1 = { tr1.Side1, tr1.Side2, tr1.Side3};
            double[] sides2 = { tr2.Side1, tr2.Side2, tr2.Side3};
            Array.Sort(sides1); Array.Sort(sides2);
            double[] relations1 = { sides1[0] / sides1[1], sides1[1] / sides1[2], sides1[2] / sides1[0]};
            double[] relations2 = { sides2[0] / sides2[1], sides2[1] / sides2[2], sides2[2] / sides2[0]};
            for (int i = 0; i < 3; i++)
            {
                if (!IsEqualDouble(relations1[i], relations2[i]))
                    return false;
            }
            return true;
        }
        public string Info(Triangle tr)
        {
            var template = "Triangle:{0}({1}, {2}, {3}){0}Reduced:{0}({4:F2}, {5:F2}, {6:F2}){0}{0}Area = {7:F2}{0}Perimeter = {8}";
            double[] sides =
            {
                tr.Side1,
                tr.Side2,
                tr.Side3
            };
            Array.Sort(sides);
            return string.Format(template, Environment.NewLine,
                sides[0], sides[1], sides[2],
                sides[0] / Perimeter(tr), 
                sides[1] / Perimeter(tr),
                sides[2] / Perimeter(tr),
                Area(tr),  Perimeter(tr));
        }
        public string InfoGreatestPerimeter(Triangle[] triangles)
        {
            double[] perimeters = new double[triangles.Length];

            for (int i = 0; i < triangles.Length; i++)
                perimeters[i] = Perimeter(triangles[i]);

            Array.Sort(perimeters);

            var maxPerimeter = perimeters[perimeters.Length - 1];

            foreach (var tr in triangles)
                if (Perimeter(tr) == maxPerimeter)
                    return Info(tr);

            return string.Empty;
        }

        public string InfoGreatestArea(Triangle[] triangles)
        {
            double[] areas = new double[triangles.Length];

            for (int i = 0; i < triangles.Length; i++)
                areas[i] = Area(triangles[i]);

            Array.Sort(areas);

            var maxArea = areas[areas.Length - 1];

            foreach (var tr in triangles)
                if (Area(tr) == maxArea)
                    return Info(tr);

            return string.Empty;
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
