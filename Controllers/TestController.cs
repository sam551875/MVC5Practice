using MVC5Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Practice.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var data = new List<Person>()
            {
                new Person() { Id = 1, Name = "Sam", age = 22},
                new Person() { Id = 2, Name = "Lin", age = 18},
                new Person() { Id = 3, Name = "Mao", age = 18},
                new Person() { Id = 4, Name = "John", age = 12},
            };

            return View(data);
        }
    }
}