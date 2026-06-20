using Microsoft.AspNetCore.Mvc;
namespace PTPMQL_MVC.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string FullName)
        {
            ViewBag.Name = "Hello " + FullName;
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}