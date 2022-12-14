using Microsoft.AspNetCore.Mvc;

namespace WebApplicationState.Controllers
{
    public class LibraryController : Controller
    {
        Dictionary<int, string> _libraryData;

        public LibraryController()
        {
            _libraryData = new Dictionary<int, string>();
            _libraryData[1] = "Wiliam";
            _libraryData[2] = "Walter";
            _libraryData[3] = "Michael";
        }
        public IActionResult Index()
        {
            return View(_libraryData);
        }

        public IActionResult Details(int id)
        {
            if(id <= _libraryData.Count)
            {
                string name = _libraryData[id];
                return View((object)name);
            }
            //return NotFound();
            return View("Error404");
        }
    }
}
