using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Managers
{
    class PersonManager : IManager<Person>
    {
        public Person Create(Person t)
        {
            using (var db = new PersonContext())
            {
               var person=   db.Persons.Add(t);
                person.Status = db.PeronsStatuses.FirstOrDefault(x => x.Id == t.Status.Id);
                db.SaveChanges();
                return person;
            }
        }

        public Person Read(int id)
        {
            using (var db = new PersonContext())
            {
                return db.Persons.Include("Status").FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Person> Read()
        {
            using (var db = new PersonContext())
            {
                return db.Persons.Include("Status").ToList();
            }
        }

        public Person Update(Person t)
        {
            using (var db = new PersonContext())
            {
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PersonContext())
            {
                db.Entry(db.Persons.FirstOrDefault(x => x.Id == id)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }
    }
}

