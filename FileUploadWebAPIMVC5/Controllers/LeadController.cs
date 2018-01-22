using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Comments(string LeadId)
        {
            var vm = new List<Comments>()
            {
                    new Comments() { id = "1", name="test"},
                    new Comments() { id = "2", name="test2"},
                    new Comments() { id = "3", name="test3"}

            };
            return PartialView("_Comments", new Comments() { id = "1", name = "test" });
        }
    }
    public class Comments
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}