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

        static List<Person> data = new List<Person>()
            {
                new Person() { Id = 1, Name = "Sam", age = 22},
                new Person() { Id = 2, Name = "Lin", age = 18},
                new Person() { Id = 3, Name = "Mao", age = 18},
                new Person() { Id = 4, Name = "John", age = 12},
            };
        public ActionResult Index()
        {
            
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save
                data.Add(person);

                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Edit(int id)
        {  

            return View(data.FirstOrDefault(p => p.Id == id));
        }        

        [HttpPost]
        public ActionResult Edit (int id, Person person)    //int id用來抓網址後面的參數，來自RouteConfig.cs的「id = UrlParameter.Optional」
        {
            if (ModelState.IsValid)
            {
                var one = data.FirstOrDefault(p => p.Id == id);                
                one.Name = person.Name;
                one.age = person.age;

                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Details(int id)
        {
            
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        public ActionResult Delete(int id)
        {
            
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var one = data.FirstOrDefault(p => p.Id == id);
            data.Remove(one);

            return RedirectToAction("Index");
        }
    }
}