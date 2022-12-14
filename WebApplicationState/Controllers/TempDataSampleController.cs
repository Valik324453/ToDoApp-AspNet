using Microsoft.AspNetCore.Mvc;

namespace WebApplicationState.Controllers
{
    public class TempDataSampleController : Controller
    {
        private string _tempDataKey = "info";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            
            if (!string.IsNullOrEmpty(value))
            {
                TempData[_tempDataKey] = value;
            }
            return View();
        }
        

        public IActionResult Read()
        {
            string? valueText = TempData[_tempDataKey] as string;
            return View(valueText as object);
        }


    }
}
