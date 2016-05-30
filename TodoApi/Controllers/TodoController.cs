using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TodoApi.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        [FromServices]
        public ITodoRepository TodoItems { get; set; }
        
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }
        
    }
}
