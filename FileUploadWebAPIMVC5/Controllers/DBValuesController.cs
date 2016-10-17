using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class dbtest
    {
        public int id { get; set; }
        public bool flag { get; set; }
    }
    [RoutePrefix("api/db")]
    public class DBValuesController : ApiController
    {
        [HttpGet]
        [Route("filltable")]
        public IHttpActionResult getdata()
        {
            return Ok(new List<dbtest>()
            {
                new dbtest() { id =1 , flag = true },
                new dbtest() { id =2 , flag = false }

            });
        }
    }
}
