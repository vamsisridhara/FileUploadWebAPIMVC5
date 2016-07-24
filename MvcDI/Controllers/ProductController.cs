using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDI.Models;

namespace MvcDI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View(repository.getProducts(new CategoryInput() { CategoryID = 1 }));
        }
    }
}