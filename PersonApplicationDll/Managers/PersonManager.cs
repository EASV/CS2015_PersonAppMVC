using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Managers
{
    class PersonManager : AbstractManager<Person>
    {
        protected override Person Create(PersonAppContext db, Person t)
        {
            return db.Persons.Add(t);
        }

        protected override Person Read(PersonAppContext db, int id)
        {
            return db.Persons.Include(x => x.Status).FirstOrDefault(x => x.Id == id);
        }

        protected override List<Person> Read(PersonAppContext db)
        {
            return db.Persons.Include(x => x.Status).ToList();
        }

        protected override void Update(PersonAppContext db, Person t)
        {
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
        }

        protected override void Delete(PersonAppContext db, int id)
        {
            var foundEntity = Read(db, id);
            db.Entry(foundEntity).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}
