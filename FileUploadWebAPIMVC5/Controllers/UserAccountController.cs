using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("api/useraccount")]
    public class UserAccountController : ApiController
    {
        private IAccountRepository _iaccrepo { get; set; }
        public UserAccountController()
        {
            _iaccrepo = new AccountRepository();
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_iaccrepo.GetAll());
        }

        [Route("getaccount/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserAccount(int id)
        {
            return Ok(_iaccrepo.GetUserAccount(id));
        }

        [Route("addaccount")]
        [HttpPost]
        public IHttpActionResult AddAccount([FromBody]UserAccount userAccount)
        {
            return Ok(_iaccrepo.Add(userAccount));
        }

        [Route("update")]
        [HttpPost]
        public IHttpActionResult update([FromBody]UserAccount userAccount)
        {
            return Ok(_iaccrepo.Update(userAccount));
        }

        [Route("remove/{id}")]
        [HttpPost]
        public IHttpActionResult remove(int id)
        {
            _iaccrepo.Remove(id);
            return Ok();
        }

    }
}
