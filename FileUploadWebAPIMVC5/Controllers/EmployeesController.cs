
using FileUploadWebAPIMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace FileUploadWebAPIMVC5.Controllers
{
    public class EmployeesController : ApiController
    {
        private static IList<Employee> list = new List<Employee>()
        {
            new Employee()
            {
                Id = 12345, FirstName = "John", LastName = "Human",Department = 2
            },
            new Employee()
            {
                Id = 12346, FirstName = "Jane", LastName = "Public",Department = 3
            },
            new Employee()
            {
                Id = 12347, FirstName = "Joseph", LastName = "Law",Department = 2
            }
        };
        
        public Employee Get(int id)
        {
            


            var employee = list.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return employee;
        }
        public IEnumerable<Employee> GetByDepartment(int department)
        {
            int[] validDepartments = { 1, 2, 3, 5, 8, 13 };
            if (!validDepartments.Any(d => d == department))
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // Unprocessable Entity
                    ReasonPhrase = "Invalid Department"
                };
                throw new HttpResponseException(response);
            }
            return list.Where(e => e.Department == department);
        }
        public IEnumerable<Employee> Get([FromUri]Filter filter)
        {
            return list.Where(e => e.Department == filter.Department &&
            e.LastName == filter.LastName);
        }
        public HttpResponseMessage Post(Employee employee)
        {
            int maxId = list.Max(e => e.Id);
            employee.Id = maxId + 1;
            list.Add(employee);
            var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, employee);
            string uri = Url.Link("DefaultApi", new { id = employee.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
