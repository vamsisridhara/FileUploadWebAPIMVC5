using FileUploadWebAPIMVC5.Data;
using FileUploadWebAPIMVC5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Description;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class ExcelApiController : ApiController
    {
        [HttpGet]
        //[ResponseType(typeof(FinalDistrict))]
        public HttpResponseMessage getDistricts(string district,string year)
        {
            HttpResponseMessage result = null;
            FinalDistrict fd = new FinalDistrict();
            fd.ienumer = DistrictBL.getDistricts();
            if (!File.Exists(fd.ienumer))
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StreamContent(new FileStream(fd.ienumer, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(fd.ienumer);
                result.Content.Headers.ContentLength = new FileInfo(fd.ienumer).Length;
            }
            return result;
        }
        //[HttpPost]
        //public HttpResponseMessage getDisFileStream()
        //{
        //    FinalDistrict fd = new FinalDistrict();
        //    fd.ienumer = DistrictBL.getDistricts();
        //    HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
        //    string result = CsvHelper(fd.ienumer.ToList());
        //    message.Content = new StringContent(result);
        //    message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //    message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        //    message.Content.Headers.ContentDisposition.FileName = "Test.csv";
        //    return message;
        //}

    }
}
