using Microsoft.AspNetCore.Mvc;
using Triangles.Services;

namespace Triangles.Controllers
{
    public class GreetingController : Controller
    {
        private GreetingServices _greetingService;

        public GreetingController()
        {
            _greetingService = new GreetingServices();
        }
        public IActionResult Index()
        {
            ViewData["message"] = _greetingService.GetGreeting();
            return View();
        }
    }
}
