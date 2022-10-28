using System.Reflection.Metadata.Ecma335;

namespace Triangles.Services
{
    public class GreetingServices : IGreeting
    {
        public string GetGreeting()
        {
            return "Hello!";
        }
    }
}
