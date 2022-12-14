using Microsoft.AspNetCore.Mvc;

namespace WebApplicationState.Controllers
{
    public class ApplicationController : Controller
    {
        private static int _counter=0;
        public IActionResult Index()
        {
            return View(_counter);
        }

        public IActionResult Increase()
        {
            _counter++;
            return RedirectToAction("Index");   
        }
        
        public IActionResult Dencrease()
        {
            _counter--;
            return RedirectToAction("Index");   
        }
    }
}
