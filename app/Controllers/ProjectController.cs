using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Baloon_AB.Models;
using Baloon_AB.Data;

namespace Baloon_AB.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("List");

        }

        public IActionResult Add(string project_name)
        {
            Project proj = new Project();
            proj.Name = project_name;
            _context.Projects.Add(proj);
            _context.SaveChanges();
            return View("List");
        }

        public IActionResult Item(int id)
        {
             Project proj = _context.Projects.Find(id);
             return View(proj);
        }
    
        public IActionResult List()
        {
            IQueryable<Project> projects = _context.Projects;
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
