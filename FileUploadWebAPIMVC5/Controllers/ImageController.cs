using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        [HttpGet]
        [Route("bytearray")]
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            //S1: Construct File Path
            var filePath = @"C:\Users\Vamsi\Desktop\DSC01108.JPG";
            if (!File.Exists(filePath)) //Not found then throw Exception
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);
            //S2:Read File as Byte Array
            byte[] fileData = File.ReadAllBytes(filePath);
            if (fileData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            // return System.Convert.ToBase64String(fileData);
            // S3: Set Response contents and MediaTypeHeaderValue
            Response.Content = new ByteArrayContent(fileData);
            Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return Response;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}