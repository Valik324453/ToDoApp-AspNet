using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplicationState.Controllers
{
    public class CacheController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            if(!_memoryCache.TryGetValue("my_saved_list", out object value))
            {
                value = LoadData();

                //1 save in cache without time
                //_memoryCache.Set("my_saved_list", value);

                //2 save cache for 15 minutes
                //_memoryCache.Set("my_saved_list", value, TimeSpan.FromSeconds(15));

                //3 save in cache for 5 sec, as expired
                _memoryCache.Set("my_saved_list", value, new MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromSeconds(5)
                });
            }
            return View(value);
        }

        public string[] LoadData()
        {
            string[] data = new string[]
            {
                "Fred",
                "Julia",
                "Boris"
            };
            return data;
        }
    }
}
