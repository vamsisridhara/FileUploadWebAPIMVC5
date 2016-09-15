using System.IO;
using System.Web.Http;
using Newtonsoft.Json;

namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        [HttpGet]
        [Route("getDetails/{zipCode}")]
        public IHttpActionResult getAddress(string zipCode)
        {
            RootObject items = null;
            var fileName = @"C:\GitHub\FileUploadWebAPIMVC5\FileUploadWebAPIMVC5\realestate\plainjquery\zipcode.json";
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    items = JsonConvert.DeserializeObject<RootObject>(reader.ReadToEnd());
                }
            }

            return Ok(items);
        }
    }
    public class ResponseData
    {
        public string city { get; set; }
        public string state { get; set; }
        public string zip5Code { get; set; }
    }

    public class RootObject
    {
        public int errorCode { get; set; }
        public ResponseData[] responseData { get; set; }
    }

}
