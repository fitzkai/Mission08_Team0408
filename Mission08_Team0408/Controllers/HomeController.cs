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
        
        public IActionResult TaskForm()
        {
            return View();
        }
    }
}
