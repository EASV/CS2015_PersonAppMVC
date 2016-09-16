using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppDll;
using AppDll.Entities;

namespace PersonWebApp.Controllers
{
    public class PersonStatusController : Controller
    {
        IManager<PersonStatus> _psm = new DllFacade().GetPersonStatusManager();
        // GET: PersonStatus
        public ActionResult Index()
        {
            return View(_psm.Read());
        }

        // GET: PersonStatus/Details/5
        public ActionResult Details(int id)
        {
            return View(_psm.Read(id));
        }

        // GET: PersonStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonStatus/Create
        [HttpPost]
        public ActionResult Create(PersonStatus personStatus)
        {
            try
            {
                // TODO: Add insert logic here
                _psm.Create(personStatus);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonStatus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonStatus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonStatus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
