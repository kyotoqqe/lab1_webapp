using System.Diagnostics;
using lab1_webapp.Models;
using Microsoft.AspNetCore.Mvc;
using lab1_webapp.Services;

namespace lab1_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailSender _emailSender;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            var apiKey = "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";
            _emailSender = new EmailSender(apiKey);
            _logger = logger;
        }

        public async Task<IActionResult> SendEmail()
        {
            await _emailSender.SendEmailAsync("wckihr@gmail.com", "Hello World", "This is the body of the email");
            Console.WriteLine("S");
            return Content("Email has been sent.");
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
    }
}
