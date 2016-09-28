using System.Collections.Generic;

namespace PersonApplicationDll.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonStatus Status { get; set; }
        public List<Wish> Wishes { get; set; }
        public List<Person> Friends { get; set; }
    }
}