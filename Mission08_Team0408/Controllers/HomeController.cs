using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0408.Models;

namespace Mission08_Team0408.Controllers
{
    public class HomeController : Controller
    {
        private TaskDbContext _taskContext;

        public HomeController(TaskDbContext context)
        {
            _taskContext = context;
        }

        public IActionResult Index()
        {
            var tasks = _taskContext.Redos.ToList();
            return View(tasks);
        }

        public IActionResult Quadrants()
        {
          return View();
        }
        [HttpGet]
        public IActionResult TaskForm()
        {
            return View("TaskForm", new Redo());
        }

        [HttpPost]
        public IActionResult TaskForm(Redo response)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Redos.Add(response);
                _taskContext.SaveChanges();
                
                return View("Quadrants", response);
            }
            else //invalid data
            {
                return View(response);
            }
        }

        [HttpPost]
        public IActionResult Edit(Redo updatedTask)
        {
            _taskContext.Update(updatedTask);
            _taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
