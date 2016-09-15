using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class PersonDemo
    {
        public string name { get; set; }
        public int id { get; set; }
    }
    [RoutePrefix("api/demo")]
    public class demoController : ApiController
    {
        [Route("savelist")]
        [HttpPost]
        public IHttpActionResult savelistofdata([FromBody] List<PersonDemo> listPerson)
        {
            var list = listPerson;

            return Ok(list.Count);
        }
    }
}
