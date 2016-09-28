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

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonStatus> PersonStatuses { get; set; }
        public DbSet<Wish> Wishes { get; set; }


    }

}
