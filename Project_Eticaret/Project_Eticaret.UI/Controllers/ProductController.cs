using Project_Eticaret.MODEL.Entites;
using Project_Eticaret.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Eticaret.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductService _productService;
        SubCategoryService _subCategoryService;
        public ProductController()
        {
            _productService = new ProductService();
            _subCategoryService = new SubCategoryService();
        }
        public ActionResult List(Guid? id)
        {
            if (id != null)
            {
                IEnumerable<Product> productListByCategory = _productService.GetDefault(x => x.SubCategoryID == id);
                return View(productListByCategory);
            }
            return Redirect("~/Home/Index");
        }

        public ActionResult Detail(Guid? id)
        {
            if (id != null)
            {
                Product model = _productService.GetByID((Guid)id);
                return View(model);
            }
            return Redirect("~/Home/Index");
        }
    }
}