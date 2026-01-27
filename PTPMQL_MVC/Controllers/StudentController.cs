namespace PTPMQL_MVC.Controllers;

using Microsoft.AspNetCore.Mvc;
using PTPMQL_MVC.Entities;


    public class StudentController : Controller
    {
        [HttpPost]
        public IActionResult Index(string Fullname, string StudentCode)
        {
            ViewBag.Message = Fullname + StudentCode;
            return View();
        }
    }