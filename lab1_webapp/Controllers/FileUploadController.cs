using Microsoft.AspNetCore.Mvc;

namespace lab1_webapp.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Метод для обработки загружаемого файла
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Файл не выбран или он пуст.";
                return View("Index");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ViewBag.Message = "Файл успешно загружен!";
            return View("Index");
        }
    }
}
