using Microsoft.AspNetCore.Mvc;
    using PTPMQL_MVC.Models.Entities;

public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Student std)
        {
            ViewBag.ThongBao = std.StudentCode + " - " + std.FullName;
            return View();
        }
    }