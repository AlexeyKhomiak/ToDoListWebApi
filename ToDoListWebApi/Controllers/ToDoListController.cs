using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToDoListWebApi.Controllers
{
    public class ToDoListController : ApiController
    {
        TodoListRepository repo = new TodoListRepository();
        // GET api/<controller>
        public IEnumerable<TodoList> Get()
        {
            return repo.GetAll();
        }

        // GET api/<controller>/5
        public TodoList Get(int id)
        {
            return repo.Get(id);
        }

        // POST api/<controller>
        public void Post([FromBody]TodoList task)
        {
            repo.Create(task);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            TodoList g = repo.Get(id);
            repo.Delete(g);
        }
    }
}