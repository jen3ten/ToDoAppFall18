using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
