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
            var tasks = _taskContext.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Quadrants()
        {
          return View();
        }
        [HttpGet]
        public IActionResult TaskForm()
        {
            
            return View("TaskForm", new Task());
        }

        [HttpPost]
        public IActionResult TaskForm(Task response)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Tasks.Add(response);
                _taskContext.SaveChanges();
                
                return View("Quadrants", response);
            }
            else // Invalid Data
            {
                return View(response);
            }
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _taskContext.Tasks
                .Single(x => x.TaskId == id);
            
            return View("TaskForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedRecord)
        {
            _taskContext.Update(updatedRecord);
            _taskContext.SaveChanges();
            return RedirectToAction("Quadrants");
        }
    }
}
