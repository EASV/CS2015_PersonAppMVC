using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenericDLL;
using GenericDLL.Entities;

namespace PersonWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IManager<Employee> _em = new GenericDllFacade().GetEmployeeManager();
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Employees = _em.Get();
            
            return View();
        }
    }
}