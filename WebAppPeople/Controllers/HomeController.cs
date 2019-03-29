using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppPeople.Models;

namespace WebAppPeople.Controllers
{
    public class HomeController : Controller
    {
        IPeopleService _peopleService;

        public HomeController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            return View(_peopleService.GetPeople());
        }
    }
}