using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace suresh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult EmployeeTime()
        {
            ViewBag.Title = "Employee Time";

            return View();
        }
        public ActionResult Payroll()
        {
            ViewBag.Title = "Payroll";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
    }
}
