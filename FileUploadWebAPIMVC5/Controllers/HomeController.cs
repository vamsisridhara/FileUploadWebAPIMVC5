using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUploadWebAPIMVC5.Models;
namespace FileUploadWebAPIMVC5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageProvider imessage;
        private readonly IStudentsGenerator istudent;
        public HomeController()
        {

        }
        //public HomeController(IMessageProvider _imes)
        //{
        //    this.imessage = _imes;
        //}
        public HomeController(IStudentsGenerator _istud)
        {
            this.istudent = _istud;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = imessage.GetMessage();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult LoadStudents(int? NoOfStudents = 5)
        {
            return View(istudent.GenerateStudents(NoOfStudents.Value));
        }
    }
    public interface IMessageProvider
    {
        string GetMessage();
    }
    public class MessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "Message from" + this.GetType();
        }
    }
}