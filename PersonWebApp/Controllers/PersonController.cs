using PersonWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PersonWebApp.Controllers
{
    public class PersonController : Controller
    {
        //Mem 1 PersonsList@111 <- Personcontroller@1
        //Mem 2 PersonsList@111 <- Personcontroller@2 John added
        //Mem 3 PersonsList@111 <- Personcontroller@3
        private static int PersonId = 1 ;

        private static readonly List<Person> Persons =
            new List<Person>
            {  new Person { Id = PersonId ++, Name = "Lars"},
               new Person { Id = PersonId ++, Name = "Bob"},
            };
       // GET: Person
        public ActionResult Index()
        {
            return View(Persons);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            person.Id = PersonId ++;
            Persons.Add(person);
            return RedirectToAction("Index");
        }

        //Sending id ,Name
        //Modelbinding
        //Complex Modelbinding
        public ActionResult StoreData(Person person)
        {
            
            Persons.Add(person);
            return RedirectToAction("Index");
        }

    }
}