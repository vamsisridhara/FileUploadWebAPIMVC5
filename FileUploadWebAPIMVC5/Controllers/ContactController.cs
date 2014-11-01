using FileUploadWebAPIMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    //[RoutePrefix("api/contacts")]
    public class ContactController : ApiController
    {
        private ContactRepository contactRepo;
        public ContactController()
        {
            this.contactRepo = new ContactRepository();
        }
        [HttpGet]
        public Contact[] Get()
        {
            return this.contactRepo.GetAllContacts();
        }
        [HttpPost]
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepo.SaveContact(contact);
            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            return response;
        }
    }
}
