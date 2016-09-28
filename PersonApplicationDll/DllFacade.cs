using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Entities;
using PersonApplicationDll.Managers;

namespace PersonApplicationDll
{
    public class DllFacade
    {
        public IManager<Person> GetPersonManager()
        {
            return new PersonListManager();
        }

        public IManager<PersonStatus> GetPersonStatusManager()
        {
           return new PersonStatusManager();
        }
    }
}
