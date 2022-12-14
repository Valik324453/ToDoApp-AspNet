using Microsoft.AspNetCore.Mvc;
using WebApplicationState.Middleware;

namespace WebApplicationState.Controllers
{
    public class HttpContextController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            HttpContext.Items["myKey"] = value;
            return View();
        }

        public IActionResult Read()
        {
            string value = HttpContext.Items["myKey"]?.ToString();
            string message = HttpContext.Items[CustomMiddleware.myCustomMiddlewareKey] as string;
            return View(value + message as object);
        }
    }
}
