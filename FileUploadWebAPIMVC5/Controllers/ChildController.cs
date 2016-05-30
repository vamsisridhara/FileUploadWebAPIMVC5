using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class ChildController : Controller
    {
        public ActionResult Index(string passtoctl)
        {
            return PartialView("~/Views/Child/Index.cshtml",passtoctl);
        }
    }
}