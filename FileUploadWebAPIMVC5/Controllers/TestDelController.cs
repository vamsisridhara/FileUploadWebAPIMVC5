using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("api/testdel")]
    public class TestDelController : ApiController
    {
        /// <summary>
        /// User id will be sent from url and list of integers will be sent via data
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Route("deleteall/{userId}")]
        [HttpPost]
        public IHttpActionResult deleteAll(String userId,List<int> ids)
        {
            //list of static ids
            var query = new List<int>() { 20, 30, 40 };
            //delete ids based on the input list of ids
            var output = query.RemoveAll(x => ids.Exists(y => y == x));
            return Ok();
        }
    }
}
