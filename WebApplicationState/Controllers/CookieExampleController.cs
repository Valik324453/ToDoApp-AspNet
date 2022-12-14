using Microsoft.AspNetCore.Mvc;

namespace WebApplicationState.Controllers
{
    public class CookieExampleController : Controller
    {
        private const string cookieName = "MyCookie";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append(cookieName, value, cookieOptions);
            return View();
        }

        public IActionResult ViewCookie()
        {
            string value = Request.Cookies[cookieName] ?? "Missing";
            return View(value as object);
        }

        public void RemoveCookie()
        {
            if (Request.Cookies[cookieName] != null)
            {
                HttpContext.Response.Cookies.Delete(cookieName);
            }
            RedirectToAction("ViewCookie");
        }
    }
}
