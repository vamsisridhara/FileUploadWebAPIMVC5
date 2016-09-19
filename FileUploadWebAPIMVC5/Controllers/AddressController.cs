using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
namespace FileUploadWebAPIMVC5.Controllers
{
    //[EnableCors(origins: "http://example.com", headers: "*", methods: "*")]
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        [HttpGet]
        [Route("getDetails/{searchTerm}")]
        public IHttpActionResult getAddress(string searchTerm)
        {
            RootObject items = null;
            dynamic query = null;
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
                    }
                }
            }
            return Ok(query);
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
