using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPeople.Models
{
    public static class DbInitializer
    {
        public static void Initialize(PeopleDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }
            else
            {
                context.Persons.Add(new Person("Ulf", "Ryd", "0709-989990"));
                context.Persons.Add(new Person("Kent", "Jönköping", "07XX-XXXXX0"));
                context.Persons.Add(new Person("Jonas", "Urhult", "07XX-XXXXX1"));
                context.Persons.Add(new Person("Erik", "Växjö", "07XX-XXXXX2"));
                context.Persons.Add(new Person("Niclas", "Växjö", "07XX-XXXXX3"));

                context.SaveChanges();
            }
        }
    }
}
