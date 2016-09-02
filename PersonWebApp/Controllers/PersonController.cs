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

        private static readonly List<Person> Persons =
            new List<Person>
            {
               new Person { Id = 1, Name = "Lars"},
                new Person { Id = 2, Name = "Bob"}
            };
       // GET: Person
        public ActionResult Index()
        {
            ViewBag.Persons = Persons;
            return View();
        }
        
        [ActionName("FindById")]
        public string Id(int id)
        {
            return GetData(id);
        }

        [NonAction]
        public string GetData(int id)
        {
            return $"id: {id} Name: Gurli";
        }

        //Sending id ,Name
        public string StoreData(Person person)
        {
            Persons.Add(person);
            return PrintPersons();
        }
        
        private string PrintPersons()
        {
            string personList = "";
            foreach (var person in Persons)
            {
                personList += "<br>";
                personList += person.Id + " - " + person.Name;
            }
            return personList;
        }
    }
}