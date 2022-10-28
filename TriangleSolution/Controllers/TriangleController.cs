using Microsoft.AspNetCore.Mvc;
using Triangles.Models;
using System; 

namespace Triangles.Controllers
{
    public class TriangleController : Controller
    {
        public string Info() { return ""; }

        // 10 15 20 => 2/3 3/4 2 
        // 20 40 30 => 3/4 2 2/3 : 1/2 4/3 3/2
        public bool AreSimilar(Triangle tr1, Triangle tr2) //task 8
        {
            double[] sides1 = { tr1.Side1, tr1.Side2, tr1.Side3 };
            double[] sides2 = { tr2.Side1, tr2.Side2, tr2.Side3 };

            Array.Sort(sides1); Array.Sort(sides2);

            double[] relations1 = { sides1[0] / sides1[1], sides1[1] / sides1[2], sides1[2] / sides1[0] };
            double[] relations2 = { sides2[0] / sides2[1], sides2[1] / sides2[2], sides2[2] / sides2[0] };

            for (int i = 0; i < 3; i++)
                if (relations1[i] != relations2[i])
                    return false;
            return true;

        }
    }
}
