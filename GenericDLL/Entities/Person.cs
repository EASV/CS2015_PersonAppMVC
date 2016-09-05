using System;

namespace GenericDLL.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        {
            return $"{Name} {Gender} - Born this year: {BirthDate.Year} - Email: {Email}";
        }
    }
    public enum Gender
    {
        Male,
        Female,
        TheOthers
    }

   
}
