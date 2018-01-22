using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("dashboard")]
    public class DashboardController : ApiController
    {
        [HttpGet]
        [Route("rptbullet")]
        public HttpResponseMessage getRptbulletData()
        {
            var json = File.ReadAllText(@"C:\DTEDashboard_new\src\assets\report-bullets.json");
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        [Route("appdata")]
        public HttpResponseMessage getappData()
        {
            var json = File.ReadAllText(@"C:\DTEDashboard_new\src\assets\dashboard-apps.json");
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        [Route("gsbulletData")]
        public HttpResponseMessage getgsbulletData()
        {
            var json = File.ReadAllText(@"C:\DTEDashboard_new\src\assets\gs-bullets.json");
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
