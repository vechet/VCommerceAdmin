using Microsoft.AspNetCore.Mvc;
using VCommerceAdmin.CustomModels;
using VCommerceAdmin.Data;
using VCommerceAdmin.Helpers;
using VCommerceAdmin.ViewModels;

namespace VCommerceAdmin.Controllers
{
    public class BrandController : Controller
    {
        private readonly VcommerceContext _db;

        public BrandController(VcommerceContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(BrandViewModel brand)
        {
            if (ModelState.IsValid)
            {
                //var responseResult = _gameProviderService.AddGameProviderUmToARecord(req);
                //return Json(responseResult);
            }
            return Json(GlobalFunction.RenderErrorMessageFromState(ModelState));
        }

        public IActionResult Edit(int id = 0)
        {
            return View("Create");
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
