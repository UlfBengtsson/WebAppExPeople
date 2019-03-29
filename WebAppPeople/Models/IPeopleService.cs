using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPeople.Models
{
    public interface IPeopleService
    {
        Person Create(string name, string city, string phone);
        Person FindById(int id);
        List<Person> GetPeople();
        bool Update(Person person);
        bool Delete(int id);
    }
}
