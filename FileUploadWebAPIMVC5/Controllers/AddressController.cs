using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
namespace FileUploadWebAPIMVC5.Controllers
{
    //[EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        [HttpGet]
        [Route("getDetails")]
        public IHttpActionResult getAddress([FromUri]string searchTerm)
        {
            RootObject items = null;
            List<ResponseData> query = null;
            var fileName = @"C:\GitHub\FileUploadWebAPIMVC5\FileUploadWebAPIMVC5\realestate\jqauto\zipcode.json";
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    items = JsonConvert.DeserializeObject<RootObject>(reader.ReadToEnd());
                    if (items != null && items.responseData != null
                        && items.responseData.Count() > 0)
                    {
                        query = items.responseData.Where(x =>
                                    x.city.Contains(searchTerm.ToUpperInvariant()) ||
                                    x.state.Contains(searchTerm.ToUpperInvariant()) ||
                                    x.zip5Code.Contains(searchTerm.ToUpperInvariant()))
                                    .Select(x => x).ToList();
                        items = new RootObject() { responseData = query };
                    }
                }
            }
            return Ok(items);
        }
        [Route("showMap/{city}")]
        public IHttpActionResult showMap(string city)
        {



            return Ok();
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
        public List<ResponseData> responseData { get; set; }
    }

}
