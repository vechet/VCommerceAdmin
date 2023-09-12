using Microsoft.AspNetCore.Mvc;

namespace VCommerceAdmin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
