using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using app.Models;

namespace app.Controllers
{
    public class ProductController : Controller
    {
        private BakeryContext context = new BakeryContext();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        private readonly ILogger<ProductController> _logger;

        public IActionResult Index()
        {
            return List();
        }

        public IActionResult Item(int id)
        {
            Product product = context.Products.Find(id);
            ViewData ["product"] = product;
            return View();
        }
        public IActionResult List()
        {
            ViewData["context"] = context;
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
    }
}
