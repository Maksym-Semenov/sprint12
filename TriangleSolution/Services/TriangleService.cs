﻿using System;
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
        public static double Area(Triangle tr)
        {
            if (Triangle.IsValid(tr))
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
        public static bool IsEquilateral(Triangle tr)
        {
            if (Triangle.IsValid(tr))
            {
                return (TriangleService.AreTwoDoublesEqual(tr.Side1, tr.Side2)
                        && TriangleService.AreTwoDoublesEqual(tr.Side1, tr.Side3)
                        && TriangleService.AreTwoDoublesEqual(tr.Side2, tr.Side3));
            }
            else
                return false;
        }
        public static bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            if(Triangle.IsValid(tr1) && Triangle.IsValid(tr2))
            {
                double[] arrayOFTriangle1Sides = new Double[3]{ tr1.Side1, tr1.Side2, tr1.Side3};
                double[] arrayOFTriangl21Sides = new Double[3]{ tr2.Side1, tr2.Side2, tr2.Side3};
                Array.Sort(arrayOFTriangle1Sides);
                Array.Sort(arrayOFTriangl21Sides);
                return (TriangleService.AreTwoDoublesEqual(arrayOFTriangle1Sides[0], arrayOFTriangl21Sides[0]) 
                        && TriangleService.AreTwoDoublesEqual(arrayOFTriangle1Sides[1], arrayOFTriangl21Sides[1]) 
                        && TriangleService.AreTwoDoublesEqual(arrayOFTriangle1Sides[2], arrayOFTriangl21Sides[2]));
            }
            else
                return false;
        }
        public static bool AreSimilar(Triangle tr1, Triangle tr2)
        {
            double[] sides1 = { tr1.Side1, tr1.Side2, tr1.Side3 };
            double[] sides2 = { tr2.Side1, tr2.Side2, tr2.Side3 };
            Array.Sort(sides1);
            Array.Sort(sides2);
            double[] relations1 = { sides1[0] / sides1[1], sides1[1] / sides1[2], sides1[2] / sides1[0] };
            double[] relations2 = { sides2[0] / sides2[1], sides2[1] / sides2[2], sides2[2] / sides2[0] };
            for (int i = 0; i < 3; i++)
            {
                if (!TriangleService.AreTwoDoublesEqual(relations1[i], relations2[i]))
                    return false;
            }
            return true;
        }
        public static string Info(Triangle tr)
        {
            var template =
                "Triangle:{0}({1}, {2}, {3}){0}Reduced:{0}({4:F2}, {5:F2}, {6:F2}){0}{0}Area = {7:F2}{0}Perimeter = {8}";
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
                Area(tr), Perimeter(tr));
        }
        public static string InfoGreatestPerimeter(Triangle[] triangles)
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
        public static string InfoGreatestArea(Triangle[] triangles)
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
        public static bool AreTwoDoublesEqual(double db1, double db2)
        {
            return Math.Abs(db1 - db2) <= db1 * 1e-5;
        }
    }
}