using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Triangles.Models;

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        // Task_01 Create an Info action that shows the info about a triangle in a form as follows:
        public string Info(Triangle tr)
        {
            if (IsValid(tr))
            {
                double[] nums = new double[3];
                nums[0] = Convert.ToDouble(tr.Side1);
                nums[1] = Convert.ToDouble(tr.Side2);
                nums[2] = Convert.ToDouble(tr.Side3);
                Array.Sort(nums);
                //double temp;
                //for (int i = 0; i < nums.Length - 1; i++)
                //{
                //    for (int j = i + 1; j < nums.Length; j++)
                //    {
                //        if (nums[i] > nums[j])
                //        {
                //            temp = nums[i];
                //            nums[i] = nums[j];
                //            nums[j] = temp;
                //        }
                //    }
                //}
                StringBuilder sb = new StringBuilder();
                sb.Append("Triangle:");
                sb.Append($"\n{nums[0]}, {nums[1]}, {nums[2]}");
                sb.Append("\nReduced:");
                sb.Append($"\n{nums[0] / Convert.ToDouble(Perimeter(tr))}, ");
                sb.Append($"{nums[1] / Convert.ToDouble(Perimeter(tr))}, ");
                sb.Append($"{nums[2] / Convert.ToDouble(Perimeter(tr))}");
                sb.Append($"\n\nArea: {Area(tr)}");
                sb.Append($"\nPerimeter: {Perimeter(tr)}");
                return sb.ToString();
                //Console.WriteLine($"Triangle:" +
                //                    $"\n{nums[0]}, {nums[1]}, {nums[2]}" +
                //                    $"\nReduced:" +
                //                    $"\n{nums[0] / Convert.ToDouble(Perimeter(tr))}" +
                //                    $", {nums[1] / Convert.ToDouble(Perimeter(tr))}" +
                //                    $", {nums[2] / Convert.ToDouble(Perimeter(tr))}" +
                //                    $"\nArea: {Area(tr)}" +
                //                    $"\nPerimeter: {Perimeter(tr)}");
                //Console.WriteLine("Triangle:");
                //Console.WriteLine("Reduced:");
                //Console.WriteLine($"{nums[0] / Convert.ToDouble(Perimeter(tr))}" +
                //                  $",{nums[1] / Convert.ToDouble(Perimeter(tr))}" +
                //                  $",{nums[2] / Convert.ToDouble(Perimeter(tr))}");
                //Console.WriteLine($"Area: {Area(tr)}");
                //Console.WriteLine($"Perimeter: {Perimeter(tr)}");
            }
            else
                throw new Exception();
            
        }
        // Task_02 Create an Area action that calculates the area of a triangle
        public string Area(Triangle tr)
        {
            if (IsValid(tr))
            {
                double halfPerimeter = (tr.Side1 + tr.Side2 + tr.Side3) / 2;
                double area = (Math.Sqrt(halfPerimeter * (halfPerimeter - tr.Side1)
                                              * (halfPerimeter - tr.Side2)
                                              * (halfPerimeter - tr.Side3)));
                return string.Format("{0:F4}", area);
            }
            else
                throw new ArgumentException();
        }
        // Task_03
        public string Perimeter(Triangle tr)
        {
            if (IsValid(tr))
                return (tr.Side1 + tr.Side2 + tr.Side3).ToString();
            else
                throw new ArgumentException();
        }
        // Task_05 Create an IsEquilateral action that returns boolean True or False
        // depending on the triangle is equilateral or not
        public bool IsEquilateral(Triangle tr)
        {
            if (IsValid(tr) && IsValid(tr.Side1, tr.Side2, tr.Side3))
            {
                return (IsEqualDouble(tr.Side1, tr.Side2)
                     && IsEqualDouble(tr.Side1, tr.Side3)
                     && IsEqualDouble(tr.Side2, tr.Side3));
            }
            else
                throw new ArgumentException();
        }
        // Task_07 Create an AreCongruent action that returns boolean True or False
        // depending on two triangles are congruent or not
        public bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            return (IsValid(tr1) && IsValid(tr2)
                             && IsEqualDouble(tr1.Side1, tr2.Side1)
                             && IsEqualDouble(tr1.Side2, tr2.Side2)
                             && IsEqualDouble(tr1.Side3, tr2.Side3));
        }
        //Task_10
        public string InfoGreatestArea(Triangle[] triangles)
        {
            double temp;
            double maxArea = 0;
            foreach (Triangle triangle in triangles)
            {
                if (IsValid(triangle))
                {
                    temp = Convert.ToDouble(Area(triangle));
                    if (temp > maxArea)
                    {
                        maxArea = temp;
                    }
                }
            }
            return maxArea.ToString();
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
