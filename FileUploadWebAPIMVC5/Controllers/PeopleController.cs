﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUploadWebAPIMVC5.Models;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData =
        {
            new Person { FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person { FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person { FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person { FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPeople()
        {
            return View(personData);
        }

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return PartialView(data);
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
    }
}