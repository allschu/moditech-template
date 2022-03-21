using Microsoft.AspNetCore.Mvc;

namespace TemplateWebApi2.WebApi.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
