﻿namespace PersonWebApp.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PersonStatus Status { get; set; }
    }
}