using GenericDLL.Entities;
using GenericDLL.Managers;

namespace GenericDLL
{
    public class GenericDllFacade
    {
        private static IManager<Person> _persons;
        private static IManager<Employee> _employees;

        public IManager<Person> GetPersonManager()
        {
            return _persons ?? (_persons = new PersonManagerFakeDb());
        }

        
        public IManager<Employee> GetEmployeeManager()
        {
            return _employees ?? (_employees = new EmployeeManagerfakeDb());
        }
    }
}
