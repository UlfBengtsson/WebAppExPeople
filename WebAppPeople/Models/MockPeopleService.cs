using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPeople.Models
{
    public class MockPeopleService : IPeopleService
    {
        int countId = 0;
        List<Person> people;

        public MockPeopleService()
        {
            people = new List<Person>();
            this.Create("Ulf", "Ryd", "0709-989990");
            this.Create("Kent", "Jönköping", "07XX-XXXXX0");
            this.Create("Jonas", "Urhult", "07XX-XXXXX1");
            this.Create("Erik", "Växjö", "07XX-XXXXX2");
            this.Create("Niclas", "Växjö", "07XX-XXXXX3");
        }

        public Person Create(string name, string city, string phone)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(phone))
            {
                return null;
            }
            Person person = new Person(countId++, name, city, phone);
            people.Add(person);
            return person;
        }

        public bool Delete(int id)
        {
            return people.Remove(people.FirstOrDefault(p => p.Id == id));
        }

        public Person FindById(int id)
        {
            return people.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> GetPeople()
        {
            return people;
        }

        public bool Update(Person person)
        {
            Person original = people.FirstOrDefault(p => p.Id == person.Id);

            if (original == null)
            {
                return false;
            }

            original.Name = person.Name;
            original.City = person.City;
            original.Phone = person.Phone;

            return true;
        }
    }
}
