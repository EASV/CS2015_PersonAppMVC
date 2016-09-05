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
               new Person { Id = 2, Name = "Bob"},
               new Person { Id = 3, Name = "Bill"},
               new Person { Id = 4, Name = "Jane"},
               new Person { Id = 5, Name = "Jill"},
               new Person { Id = 6, Name = "Samuel"},
               new Person { Id = 7, Name = "Jesica"}

            };
       // GET: Person
        public string Index()
        {
            return PrintPersons(Persons);
        }
        
        [ActionName("Single")]
        public string Id(int id)
        {
            var person = Persons.FirstOrDefault(x => x.Id == id);
            return person != null ? person.Id + " " + person.Name : "Not found";
        }

        [ActionName("First")]
        public string GetFirst(int count)
        {
            if (count <= 0) return "Count must be above 0";
            if (count > Persons.Count)
            {
                return PrintPersons(Persons);
            }
            var persons = Persons.GetRange(0, count);
            return PrintPersons(persons);
        }

        [ActionName("Sorted")]
        public string GetSorted(bool? desc)
        {
            if (desc.HasValue && desc.Value)
            {
                return PrintPersons(Persons.OrderByDescending(x => x.Name).ToList());
            }
            return PrintPersons(Persons.OrderBy(x => x.Name).ToList());
        }

        [ActionName("Paged")]
        public string GetPaged(int page, int itemsPrPage, bool desc)
        {
            if (page <= 0 || itemsPrPage <= 0 || ((page - 1) * itemsPrPage) > Persons.Count)
            {
                return "Bad, page must be above 0 and itemsprpage must be above 0";
            }
            var pagedList = Persons
              .Skip((page - 1) * itemsPrPage)
              .Take(itemsPrPage);
            if (desc)
            {
                return PrintPersons(pagedList.OrderByDescending(x => x.Name).ToList());
            }
            return PrintPersons(pagedList.OrderBy(x => x.Name).ToList());
        }



        //Sending id ,Name
        public string StoreData(Person person)
        {
            Persons.Add(person);
            return PrintPersons(Persons);
        }

        
        private string PrintPersons(IEnumerable<Person> persons )
        {
            var personList = "";
            foreach (var person in persons)
            {
                personList += "<div style='overflow: hidden; white-space: nowrap; '>" +
                        "<p style='color:darkblue'>" + person.Name + " - " + person.Id + "</p>"+
                    "</div>";
            }
            return personList;
        }
    }
}