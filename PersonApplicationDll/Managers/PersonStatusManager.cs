using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Context;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Managers
{
    class PersonStatusManager : IManager<PersonStatus>
    {
        public PersonStatus Create(PersonStatus t)
        {
            using (var db = new PersonContext())
            {
                var status = db.PeronsStatuses.Add(t);
                db.SaveChanges();
                return status;
            }
        }

        public PersonStatus Read(int id)
        {
            using (var db = new PersonContext())
            {
                return db.PeronsStatuses.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<PersonStatus> Read()
        {
            using (var db = new PersonContext())
            {
                return db.PeronsStatuses.ToList();
            }
        }

        public PersonStatus Update(PersonStatus t)
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
                db.Entry(db.PeronsStatuses.FirstOrDefault(x => x.Id == id)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return true;
            }
        }
    }
}
