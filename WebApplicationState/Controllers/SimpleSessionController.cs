using Microsoft.AspNetCore.Mvc;

namespace WebApplicationState.Controllers
{
    public class SimpleSessionController : Controller
    {
        private const string sessionKey = "Test data in Session";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            //if (value != null)
            //{
            //    //set value in session
            //    HttpContext.Session.SetString(sessionKey, value);
            //}

            if (!string.IsNullOrEmpty(value))
            {
                //set value in session
                HttpContext.Session.SetString(sessionKey, value);
            }

            return View();
            
        }

        public IActionResult Read()
        {
            string? savedValue = HttpContext.Session.GetString(sessionKey); //?? "Missing value";
            return View(savedValue as object);
        }
    }
}
