using Microsoft.AspNetCore.Mvc;

namespace WebApplicationState.Controllers
{
    public class SampleController : Controller
    {
        private static string _controlerState;
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            _controlerState = value;
            return View();
        }

        public IActionResult Test()
        {
            return View(_controlerState as object);
        }
    }
}
