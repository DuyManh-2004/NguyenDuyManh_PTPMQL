using Microsoft.AspNetCore.Mvc;
using PTPMQL_MVC.Models;
using System.Diagnostics;

namespace YourProjectName.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Hello Nguyễn Duy Mạnh - MSSV: 2221050029";
            return View();
        }
    }
}

