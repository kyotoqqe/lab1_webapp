using System.Diagnostics;
using lab1_webapp.Models;
using lab1_webapp.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace lab1_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var apiKey = "key-example"; // Ваш ключ
            _emailSender = new EmailSender(apiKey);
        }
        public IActionResult Submit()
        {
            var model = new UserModel(); // Если нужно, можно передать пустую или заполненную модель
            return View(model); // Передаем модель в представление
        }
        [HttpPost]
        public IActionResult Submit(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Content("Validation passed!");
        }


        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
            );

            return LocalRedirect(returnUrl ?? "/");
        }
        public async Task<IActionResult> SendEmail()
        {
            try
            {
                // Пример отправки email
                await _emailSender.SendEmailAsync("recipient@example.com", "Test Subject", "This is the body of the email.");
                return Content("Email has been sent.");
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                _logger.LogError(ex, "Error occurred while sending email.");
                return Content("Failed to send email.");
            }
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
