using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Managers
{
    internal class PersonStatusManager : IManager<PersonStatus>
    {
        public PersonStatus Create(PersonStatus t)
        {
            using (var db = new PersonAppContext())
            {
                db.PersonStatuses.Add(t);
                db.SaveChanges();
                return t;
            }
        }

        public PersonStatus Read(int id)
        {
            using (var db = new PersonAppContext())
            {
                return db.PersonStatuses.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<PersonStatus> Read()
        {
            using (var db = new PersonAppContext())
            {
                return db.PersonStatuses.ToList();
            }
        }

        public PersonStatus Update(PersonStatus t)
        {
            using (var db = new PersonAppContext())
            {
                //3. Mark entity as modified
                db.Entry(t).State = System.Data.Entity.EntityState.Modified;

                //4. call SaveChanges
                db.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new PersonAppContext())
            {
                var personStatus = Read(id); 
                db.Entry(personStatus).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
                return Read(id) == null;
            }
        }
    }
}
