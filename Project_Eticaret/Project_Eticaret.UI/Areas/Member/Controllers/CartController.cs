using Project_Eticaret.MODEL.Entites;
using Project_Eticaret.SERVICE.Option;
using Project_Eticaret.UI.Areas.Member.Data;
using Project_Eticaret.UI.Areas.Member.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Eticaret.UI.Areas.Member.Controllers
{
    public class CartController : Controller
    {
        // GET: Member/Cart
        ProductService _productService;

        public CartController()
        {
            _productService = new ProductService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                List<ProductVM> productList = cart.CartProductList.Select(x => new ProductVM
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitInStock = x.UnitInStock,
                    Quantity = x.Quantity,
                    ImagePath = x.ImagePath
                }).ToList();

                return Json(productList, JsonRequestBehavior.AllowGet);
            }

            return Json("Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Guid id)
        {
            Product product = _productService.GetByID(id);

            ProductVM vm = new ProductVM
            {
                ID = product.ID,
                ProductName = product.Name,
                UnitPrice = product.Price,
                UnitInStock = product.UnitInStock,
                Quantity = 1,
                ImagePath = product.ImagePath
            };

            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(vm);
                Session["sepet"] = cart;
            }
            else
            {
                ProductCart cart = new ProductCart();
                cart.AddCart(vm);
                Session.Add("sepet", cart);
            }

            return Json("");
        }

        public JsonResult DecreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }

        public JsonResult IncreaseCart(Guid id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.IncreaseCart(id);
            Session["sepet"] = cart;

            return Json("");
        }

        public JsonResult Remove(Guid id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.RemoveCart(id);
            Session["sepet"] = cart;

            return Json("");
        }
    }
}