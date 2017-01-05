using System.Linq;
using System.Web;
using System.Web.Http;
using System.IO;
using System.IO.Compression;
namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("api/fileupload")]
    public class FileUploadController : ApiController
    {
        //upload zip files
        [HttpPost]
        [Route("uploadzipfiles")]
        public System.Web.Mvc.JsonResult uploadzipFiles()
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
                        // Get the complete file path
                        filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(Path.Combine(filePath, httpPostedFile.FileName));

                        //unzip the files
                        ZipFile.ExtractToDirectory(Path.Combine(filePath, httpPostedFile.FileName),
                            filePath);

                        //delete the zip file
                        File.Delete(Path.Combine(filePath, httpPostedFile.FileName));

                        //move the files to folder
                        var files = Directory.GetFiles(Path.Combine(filePath, Path.GetFileNameWithoutExtension(httpPostedFile.FileName)));
                        foreach (var file in files)
                        {
                            if (!File.Exists(Path.Combine(filePath, Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file))))
                            {
                                File.Copy(file, Path.Combine(filePath, Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file)));
                            }
                            else
                            {
                                File.Delete(file);
                            }
                        }
                        Directory.Delete(Path.Combine(filePath, Path.GetFileNameWithoutExtension(httpPostedFile.FileName)), true);
                    }
                }
            }
            return new System.Web.Mvc.JsonResult()
            {
                Data = getFileNames(filePath)
            };
        }

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
                        httpPostedFile.SaveAs(Path.Combine(filePath,
                            Path.GetFileNameWithoutExtension(httpPostedFile.FileName) + ".txt"));
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
