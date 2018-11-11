using DAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Mvc;

namespace ToDoListWebApi.Infrastructure
{
    public class CustomDependencyResolver: System.Web.Mvc.IDependencyResolver
    {
        IKernel kernel;
        public CustomDependencyResolver()
        {
            kernel = new StandardKernel();
            kernel.Bind<IRepository<TodoList>>().To<TodoListRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

    }
}