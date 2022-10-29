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
        public string Info(Triangle tr)
        {
            return TriangleService.Info(tr);
        }
        public double Area(Triangle tr)
        {
            return TriangleService.Area(tr);
        }
        public double Perimeter(Triangle triangle)
        {
            return TriangleService.Perimeter(triangle);
        }
        public bool IsRightAngled(Triangle triangle)
        {
            return TriangleService.IsRightAngled(triangle);
        }
        public bool IsEquilateral(Triangle tr)
        {
            return TriangleService.IsEquilateral(tr);
        }
        public bool IsIsosceles(Triangle triangle)
        {
            return TriangleService.IsIsosceles(triangle);
        }
        public bool AreCongruent(Triangle tr1, Triangle tr2)
        {
            return TriangleService.AreCongruent(tr1, tr2);
        }
        public bool AreSimilar(Triangle tr1, Triangle tr2)
        {
            return TriangleService.AreSimilar(tr1, tr2);
        }
        public string InfoGreatestPerimeter(Triangle[] triangles)
        {
            return TriangleService.InfoGreatestPerimeter(triangles);
        }
        public string InfoGreatestArea(Triangle[] triangles)
        {
            return TriangleService.InfoGreatestArea(triangles);
        }
        public string NumbersPairwiseNotSimilar(Triangle[] triangles)
        {
            return TriangleService.NumbersPairwiseNotSimilar(triangles);
        }
    }
}