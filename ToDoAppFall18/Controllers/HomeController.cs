using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppFall18.Models;

namespace ToDoAppFall18.Controllers
{
    public class HomeController : Controller
    {
        private IToDoRepository repo;

        public HomeController(IToDoRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Index()
        {
            var expected = repo.GetAll();
            //expected is the model
            return View(expected);
        }

        public ViewResult Details(int id)
        {
            var model = repo.GetById(id);
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [AcceptVerbs("POST")] 
        public IActionResult Create(ToDo todo)
        {
            repo.Create(todo);
            //return View(); 
            //Return user to Index view by calling the Index action
            return RedirectToAction("Index");
        }

        public ViewResult Delete(int id)
        {
            var model = repo.GetById(id);
            return View(model);
        }
    }
}
