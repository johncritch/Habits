using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Habits.Models;

namespace Habits.Controllers
{
    public class HomeController : Controller
    {
        private TaskDataContext _theContext { get; set; }


        //Constructor
        public HomeController(TaskDataContext theContext)
        {
            _theContext = theContext;
        }

        public IActionResult Index()
        {
            var tasks = _theContext.Tasks
                .Include(x => x.Category)
                //.OrderBy(film => T)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _theContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                _theContext.Add(tr);
                _theContext.SaveChanges();

                return View("Index");
            }
            else
            {
                ViewBag.Categories = _theContext.Categories.ToList();

                return View(tr);
            }
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _theContext.Categories.ToList();

            var task = _theContext.Tasks.Single(x => x.TaskID == taskid);

            return View("Add", task);

        }

        [HttpPost]
        public IActionResult Edit(TaskResponse tr)
        {
            _theContext.Update(tr);
            _theContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = _theContext.Tasks.Single(x => x.TaskID == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            _theContext.Tasks.Remove(tr);
            _theContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
