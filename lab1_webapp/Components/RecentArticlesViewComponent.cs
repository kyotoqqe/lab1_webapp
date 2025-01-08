using Microsoft.AspNetCore.Mvc;


namespace lab1_webapp.Components
{
    public class RecentArticlesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = new List<string>
            {
                "Стаття 1",
                "Стаття 2",
                "Стаття 3"
            };

            // Передача даних у View
            return View(articles);
        }
    }
}
