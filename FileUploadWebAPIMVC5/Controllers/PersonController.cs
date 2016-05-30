using FileUploadWebAPIMVC5.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class PersonController : Controller
    {
        private Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                };
        IValueCalculator calc;
        public PersonController(IValueCalculator calcParam, IValueCalculator calc2)
        {
            this.calc = calcParam;
        }
        // GET: Person
        public ActionResult Index()
        {
            ShoppingCart shop = new ShoppingCart(calc) { Products = products };
            return View(shop.CalculateProductTotal());
        }
    }
}