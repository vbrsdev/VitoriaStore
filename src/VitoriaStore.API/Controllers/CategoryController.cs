using Microsoft.AspNetCore.Mvc;

namespace VitoriaStore.API.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
