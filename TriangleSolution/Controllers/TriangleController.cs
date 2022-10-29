using Microsoft.AspNetCore.Mvc;
using Triangles.Models;
using Triangles.Services;
using Triangles.Filters;

namespace Triangles.Controllers
{
    [ValidationTriangle]
    public class TriangleController : Controller
    {
        public string Info(Triangle triangle)
        {
            return TriangleService.Info(triangle);
        }
        public double Area(Triangle triangle)
        {
            return TriangleService.Area(triangle);
        }
        public double Perimeter(Triangle triangle)
        {
            return TriangleService.Perimeter(triangle);
        }
        public bool IsRightAngled(Triangle triangle)
        {
            return TriangleService.IsRightAngled(triangle);
        }
        public bool IsEquilateral(Triangle triangle)
        {
            return TriangleService.IsEquilateral(triangle);
        }
        public bool IsIsosceles(Triangle triangle)
        {
            return TriangleService.IsIsosceles(triangle);
        }
        public bool AreCongruent(Triangle triangle1, Triangle triangle2)
        {
            return TriangleService.AreCongruent(triangle1, triangle2);
        }
        public bool AreSimilar(Triangle triangle1, Triangle triangle2)
        {
            return TriangleService.AreSimilar(triangle1, triangle2);
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