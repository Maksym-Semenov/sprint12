using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Triangles.Models;

namespace Triangles.Filters
{
    public class ValidationTriangleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                StringValues side1, side2, side3;
                
                if (context.HttpContext.Request.Query.TryGetValue("side1", out side1)
                    && context.HttpContext.Request.Query.TryGetValue("side2", out side2)
                    && context.HttpContext.Request.Query.TryGetValue("side3", out side3))
                {
                    if (side1.Any() && side2.Any() && side3.Any())
                    {
                        var doubleSide1 = Convert.ToDouble(side1);
                        var doubleSide2 = Convert.ToDouble(side2);
                        var doubleSide3 = Convert.ToDouble(side3);
                        
                        if(!Triangle.IsValid(new Triangle(doubleSide1, doubleSide2, doubleSide3)))
                        {
                            throw new Exception("Invalid triangle");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                context.Result = new BadRequestObjectResult(e.Message);
            }
        }
    }
}