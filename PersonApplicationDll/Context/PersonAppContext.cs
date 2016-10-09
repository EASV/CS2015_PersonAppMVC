using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Context
{
    public class PersonAppContext : DbContext
    {
        public PersonAppContext() : base()
        {
            Database.SetInitializer(new DataBaseInitializer());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonStatus> PersonStatuses { get; set; }
        public DbSet<Wish> Wishes { get; set; }


    }

    public class DataBaseInitializer : DropCreateDatabaseAlways<PersonAppContext>
    {
        protected override void Seed(PersonAppContext db)
        {
            var defaultStatus = new PersonStatus() {Name = "At Home"};
            db.PersonStatuses.Add(defaultStatus);
            db.PersonStatuses.Add(new PersonStatus() { Name = "At Work" });
            db.PersonStatuses.Add(new PersonStatus() { Name = "In Spain" });

            db.Persons.Add(new Person() {Name = "Bill", Status = defaultStatus});
            db.Persons.Add(new Person() { Name = "Joe", Status = defaultStatus });
            db.Persons.Add(new Person() { Name = "Jill", Status = defaultStatus }); 
            db.Persons.Add(new Person() { Name = "Billy", Status = defaultStatus }); 
            
            base.Seed(db);
        }
    }
}
