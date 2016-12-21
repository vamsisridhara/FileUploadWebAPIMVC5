using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class FileUploadController : ApiController
    {
        

        [HttpPost]
        public System.Web.Mvc.JsonResult UploadFile()
        {
            string filePath = string.Empty;
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                int count = HttpContext.Current.Request.Files.AllKeys.Count();
                for (int filecount = 0; filecount < count; filecount++)
                {
                    // Get the uploaded image from the Files collection
                    var contextFileName = "UploadedImage" + filecount;
                    var httpPostedFile = HttpContext.Current.Request.Files[contextFileName];
                    if (httpPostedFile != null)
                    {
                        // Validate the uploaded image(optional)

                        // Get the complete file path
                        filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(Path.Combine(filePath, Path.GetFileNameWithoutExtension(httpPostedFile.FileName) + ".txt"));
                    }
                }

            }
            return new System.Web.Mvc.JsonResult()
            {
                Data = getFileNames(filePath)
            };
        }
        private string[] getFileNames(string filePath)
        {
            string[] uploadedFiles = null;
            if (Directory.GetFiles(filePath).Count() > 0)
            {
                uploadedFiles = Directory.GetFiles(filePath).Select(path => Path.GetFullPath(path)).ToArray();
            }
            return uploadedFiles;
        }
    }
}
