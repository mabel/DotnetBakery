using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.Extensions.Logging;
using Baloon_AB.Models;
using Baloon_AB.Data;

namespace Baloon_AB.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Add([FromServices] ApplicationDbContext context, string project_name, string user_name)
        {
            if(project_name == null) return RedirectToAction("List");
            Project proj = new Project();
            proj.Name = project_name;
            proj.UserId = user_name;
            proj.InitDate = DateTime.Now;
            context.Projects.Add(proj);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Del([FromServices] ApplicationDbContext context, int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Project proj = context.Projects.Find(id);
            if (proj == null)
            {
                return NotFound();
            }
            context.Projects.Remove(proj);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit([FromServices] ApplicationDbContext context, int? id, string Name, DateTime InitDate)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Project proj = context.Projects.Find(id);
            if (proj == null)
            {
                return NotFound();
            }
            proj.Name = Name;
            proj.InitDate = InitDate;
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Item([FromServices] ApplicationDbContext context, int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Project proj = context.Projects.Find(id);
            if (proj == null)
            {
                return NotFound();
            }
            return View(proj);
        }
    
        public IActionResult List([FromServices] ApplicationDbContext context)
        {
            IQueryable<Project> projects = context.Projects
                //.Where(p => p.Name.Contains(User.Identity.Name))
                ;
            return View(projects.ToList());
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
    }
}
