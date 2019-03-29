using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPeople.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public Person() {}

        public Person(string name, string city, string phone)
        {
            Name = name;
            City = city;
            Phone = phone;
        }

        public Person(int id, string name, string city, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            Phone = phone;
        }
    }
}
