using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        Dictionary<string, TodoItem> _todos = new Dictionary<string, TodoItem>();
        public TodoRepository()
        {
            Add(new TodoItem() { Name = "item1" });
        }
        public void Add(TodoItem item)
        {
            item.Key = new Guid().ToString();
            _todos.Add(item.Key,item);
        }

        TodoItem ITodoRepository.Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        IEnumerable<TodoItem> ITodoRepository.GetAll()
        {
            return _todos.Values;
        }

        TodoItem ITodoRepository.Remove(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            _todos.Remove(key);
            return item;
        }

        void ITodoRepository.Update(TodoItem item)
        {
            _todos[item.Key] = item;
        }
    }
}
