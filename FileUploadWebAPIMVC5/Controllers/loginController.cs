using System.Net.Http;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    public class LoginViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    [RoutePrefix("api/login")]
    public class loginController : ApiController
    {
        [HttpPost]
        [Route("validate")]
        public HttpResponseMessage validate(LoginViewModel loginmodel)
        {
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            if (loginmodel.username.Equals("test") && loginmodel.password.Equals("test"))
            {

            }
            else
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }
    }
}