using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AglInterviewTest.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
        public List<Person> Persons{ get;set; }
    }
}