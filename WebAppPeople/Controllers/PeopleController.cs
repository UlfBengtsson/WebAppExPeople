using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppPeople.Models;

namespace WebAppPeople.Controllers
{
    public class PeopleController : Controller
    {

        IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Person(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Person", person);
        }

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Details", person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return PartialView("_Edit", person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {

            if (person == null )
            {
                return NotFound();
            }

            if (_peopleService.Update(person))
            {
                return PartialView("_Person", person);
            }
            else
            {
                return PartialView("_Edit", _peopleService.FindById(person.Id));
            }
            
        }

        [HttpPost]
        public IActionResult Create(string name, string city, string phone)
        {

            Person person = _peopleService.Create(name, city, phone);

            if (person == null)
            {
                return BadRequest(new { msg = "All inputs must have a value." });
            }

            return PartialView("_Person", person);

        }

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            _peopleService.Delete(id);

            return Content("");
        }

        public IActionResult Filter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return PartialView("_List", _peopleService.GetPeople());
            }

            filter = filter.ToLower();

            return PartialView("_List", _peopleService.GetPeople()
                .Where(p => p.Name.ToLower().Contains(filter) || p.City.ToLower().Contains(filter))
                .ToList());
        }
    }
}