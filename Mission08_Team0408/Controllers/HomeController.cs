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
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
