using System.Collections.Generic;
using System.Linq;
using GenericDLL.Entities;

namespace GenericDLL.Managers
{
    class EmployeeManagerfakeDb : IManager<Employee>
    {
        private static int Id = 1;

        private readonly List<Employee> _persons = new List<Employee>();

        public EmployeeManagerfakeDb()
        {
            Create(new Employee { Id=1,Name = "Lars", Email = "larsb@namnam.dk"});

            Create(new Employee { Id = 2, Name = "Ole", Email = "ILoveBigBirds@zoo.com"});
        }

        public List<Employee> Get()
        {
            return new List<Employee>(_persons);
        }

        public Employee Create(Employee p)
        {
            _persons.Add(p);
            p.Id = Id++;
            return p;
        }

        public bool Delete(Employee p)
        {
            /*foreach (var person in persons)
            {
                if (person.Id == p.Id)
                {
                    persons.Remove(person);

                }

            }*/



            _persons.RemoveAll(person => person.Id == p.Id);


            return _persons.FirstOrDefault(person => person.Id == p.Id) == null;
        }

        public Employee Get(int id)
        {
            /*foreach (var person in persons)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }*/
            //return null;
            return _persons.FirstOrDefault(person => person.Id == id);
        }

        public Employee Update(Employee p)
        {
            var personFound = _persons.FirstOrDefault(person => person.Id == p.Id);
            if (personFound != null)
            {
                personFound.Name = p.Name;
            }
            return personFound;
        }


        /*public Person UpdatePerson(Person person)
        {
            if (person == null) new NullReferenceException();

            var personInDb = persons.FirstOrDefault(x => x.Id == person.Id);

            if (personInDb != null) personInDb.Name = person.Name;

            return person;
        }*/
    }
}
