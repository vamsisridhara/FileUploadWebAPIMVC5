using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MvcDI.Models;

namespace MvcDI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductApiController : ApiController
    {
        public ProductApiController()
        {

        }
        private IProductRepository repository;
        public ProductApiController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        [HttpPost]
        [Route("getall")]
        [ResponseType(typeof(List<ProductVM>))]
        public IHttpActionResult Index(CategoryInput input)
        {
            return Ok(repository.getProducts(input));
        }
    }
}
