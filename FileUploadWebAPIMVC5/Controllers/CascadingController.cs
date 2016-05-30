using FileUploadWebAPIMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileUploadWebAPIMVC5.Controllers
{
    [RoutePrefix("cascade")]
    public class CascadingController : ApiController
    {

        [HttpGet]
        [Route("getmanagers")]
        public List<Manager> getmanagers() {
            return FetchData.getmanagers();
        }

        [HttpGet]
        [Route("getemployees/{empname}")]
        public IEnumerable<Department> getemployees(string empname)
        {
            return FetchData.getmanagers().
                        SelectMany(x => x.Employees.Where(y=>y.EmployeeName == empname).
                        SelectMany(z=>z.DeptList)).Distinct();
        }

        [HttpGet]
        [Route("getemployees/{empname}/{dept}")]
        public IEnumerable<Department> getlocation(string empname, string dept)
        {
            //return null;
            return FetchData.getmanagers().
                         SelectMany(x => x.Employees.Where(y => y.EmployeeName == empname).
                         SelectMany(z => z.DeptList));
        }
    }
}