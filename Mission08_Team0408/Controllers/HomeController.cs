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
            var tasks = _taskContext.ToDos.ToList();
            return View(tasks);
        }

        public IActionResult Quadrants()
        {
            List<ToDo> todos = _taskContext.ToDos
                .Include(x => x.Category)
                .OrderBy(x => x.Quadrant)
                .ToList();
            return View(todos);
        }


        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = _taskContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("TaskForm", new ToDo());
        }

        [HttpPost]
        public IActionResult TaskForm(ToDo response)
        {
            if (ModelState.IsValid)
            {
                _taskContext.ToDos.Add(response);
                _taskContext.SaveChanges();

                return View("Submit", response);
            }
            else //invalid data
            {
                ViewBag.Categories = _taskContext.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _taskContext.ToDos
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _taskContext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("TaskForm", taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ToDo updatedTask)
        {
            _taskContext.Update(updatedTask);
            _taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _taskContext.ToDos
                .SingleOrDefault(x => x.TaskId == id);  // Ensure we return a null or throw exception if not found

            if (taskToDelete == null)
            {
                return NotFound();  // Return NotFound if no task was found with the given ID
            }

            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(ToDo taskToDelete)
        {
            _taskContext.ToDos.Remove(taskToDelete);  // Remove the task from the DbContext
            _taskContext.SaveChanges();  // Save the changes to the database

            return RedirectToAction("Quadrants");
        }
    }
}
