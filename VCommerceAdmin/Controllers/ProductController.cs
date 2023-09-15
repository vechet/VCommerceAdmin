using Microsoft.AspNetCore.Mvc;

namespace VCommerceAdmin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}