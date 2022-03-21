using Microsoft.AspNetCore.Mvc;

namespace TemplateWebApi2.WebApi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
