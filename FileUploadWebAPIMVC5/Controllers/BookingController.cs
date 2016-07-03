using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUploadWebAPIMVC5.Models;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public ViewResult MakeBooking()
        {
            return View(new Appointment() { ClientName = "Test", TermsAccepted = true, Date = DateTime.Now });
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appt)
        {
            // statements to store new Appointment in a
            // repository would go here in a real project
            return Json(appt, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult MakeBooking(Appointment appt)
        //{
        //    if (string.IsNullOrEmpty(appt.ClientName))
        //    {
        //        ModelState.AddModelError("ClientName", "Please enter your name");
        //    }
        //    if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
        //    {
        //        ModelState.AddModelError("Date", "Please enter a date in the future");
        //    }
        //    if (!appt.TermsAccepted)
        //    {
        //        ModelState.AddModelError("TermsAccepted", "You must accept the terms");
        //    }
        //    if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date")
        //            && appt.ClientName == "Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday)
        //    {
        //        ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
        //    }

        //    if (ModelState.IsValid)
        //        return View("Completed", appt);
        //    else
        //        return View();
        //}
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)", JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}