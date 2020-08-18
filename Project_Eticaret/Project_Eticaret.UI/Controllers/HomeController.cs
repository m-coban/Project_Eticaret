using Project_Eticaret.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Eticaret.UI.Controllers
{
    public class HomeController : Controller
    {
        CategoryService _categoryService;
        ProductService _productService;
        public HomeController()
        {
            _categoryService = new CategoryService();
            _productService = new ProductService();
        }
        public ActionResult Index()
        {
            var model = _productService.GetDefault(x => x.UnitInStock > 0).OrderByDescending(x => x.CreatedDate).Take(16).ToList();
            return View(model);
        }

        // Buradaki metot, PartialView()'ı yönlendirmek için kullanılır. ChildActionOnly attribute'u, bu action'ı sadece bu durumlarda çağırabileceğini belirtir. Bu attribute OPSİYONELdir.
        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            return PartialView("_CategoryList", _categoryService.GetActive());
        }

        public ActionResult Login()
        {
            return View();
        }

        public RedirectResult LogOut()
        {
            return Redirect("Home/Index");
        }
    }
}