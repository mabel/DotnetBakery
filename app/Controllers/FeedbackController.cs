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
    public class FeedbackController : Controller
    {
        private BakeryContext context = new BakeryContext();
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(ILogger<FeedbackController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return List();
        }

        //users_name=Mike&mark=4&product_id=1&users_id=f1490b0cd6b37fb646930a3ae1769d39&feedback=hi
        public IActionResult Add(string users_id, string users_name, string feedback, int mark, int product_id)
        {

            User user = context.Users.Find(users_id);
            if(user == null){
                //Console.WriteLine("No such user!");
                user = new User();
                user.Id = users_id;
                user.Name = users_name;
                context.Users.Add(user);
            }
            Feedback fb = new Feedback();
            fb.ProductId = product_id;
            fb.Description = feedback;
            fb.UserId = users_id;
            fb.Mark = mark;
            context.Feedbacks.Add(fb);
            context.SaveChanges();
            return View();
        }

        public IActionResult List()
        {
            IQueryable<FeedbackRow> feedbacks = context.FeedbackRows;
            return View(feedbacks.ToList());
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
