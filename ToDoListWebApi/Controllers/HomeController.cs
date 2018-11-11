using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoListWebApi.Controllers
{
    public class HomeController : Controller
    {
        IRepository<TodoList> repo;
        public HomeController(IRepository<TodoList> r)
        {
            repo = r;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGoodsById(int id)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(repo.GetAll().Where(x => x.Id == id).Select(x => new { GoodName = x.TaskName }),
                Newtonsoft.Json.Formatting.Indented,
                new Newtonsoft.Json.JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            return new JsonResult { Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}