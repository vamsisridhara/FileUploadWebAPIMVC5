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
    [RoutePrefix("api/sampledownload")]
    public class FileDownloadController : ApiController
    {
        [HttpGet]
        [Route("getdata/{filepath}")]
        public HttpResponseMessage downloadfile(string filepath)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream file = new FileStream(Path.Combine(@"c:\download", filepath + ".csv"),
                    FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms.Write(bytes, 0, (int)file.Length);
                    result.Content = new ByteArrayContent(bytes.ToArray());
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    result.Content.Headers.ContentDisposition = new
                        ContentDispositionHeaderValue("attachment")
                    { FileName = "book1.csv" };
                }
            }
            return result;
        }
    }
}
