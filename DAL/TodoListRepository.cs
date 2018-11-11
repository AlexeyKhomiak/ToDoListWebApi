using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TodoListRepository : IRepository<TodoList>
    {
        ToDoListDataEntities db = new ToDoListDataEntities();
        public IEnumerable<TodoList> GetAll()
        {
            return db.TodoList;
        }

        public TodoList Get(int id)
        {
            return db.TodoList.Find(id);
        }

        public void Create(TodoList obj)
        {
            db.TodoList.AddOrUpdate(obj);
            db.SaveChanges();
        }

        public List<string> Delete(TodoList obj)
        {
            db.TodoList.Remove(obj);
            db.SaveChanges();
            List<string> tasks = new List<string>();
            return tasks;
        }
        public void Update(TodoList obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        
    }
}
