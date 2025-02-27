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

        //public IActionResult QuadrantView()
        //{
        //    var records = _taskContext.Redos.ToList(); // Fetch records from DB

        //    // Ensure mapping from entity (Redo) to ViewModel (RedoViewModel)
        //    var model = new RedoViewModel
        //    {
        //        Records = records.Select(r => new Redo
        //        {
        //            TaskId = r.TaskId, 
        //            TaskName = r.TaskName,
        //            DueDate = r.DueDate,
        //            Quadrant = r.Quadrant,
        //            Category = r.Category,
        //            Completed = r.Completed
        //        }).ToList() // Convert list of entities to list of ViewModel objects
        //    };

        //    return View(model);
        //}


        public IActionResult TaskForm()
        {
            return View();
        }
    }
}
