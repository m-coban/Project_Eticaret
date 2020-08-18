using Project_Eticaret.MODEL.Entites;
using Project_Eticaret.SERVICE.Option;
using Project_Eticaret.UI.Areas.Member.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Eticaret.UI.Areas.Member.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Member/CheckOut
        OrderService _orderService;
        ProductService _productService;
        AppUserService _appUserService;
        public CheckoutController()
        {
            _orderService = new OrderService();
            _productService = new ProductService();
            _appUserService = new AppUserService();
        }
        public ActionResult Add()
        {
            if (Session["sepet"] == null)
            {
                return Redirect("/Home/Index");
            }

            ProductCart cart = Session["sepet"] as ProductCart;
            Order o = new Order();
            AppUser user = _appUserService.FindByUserName(HttpContext.User.Identity.Name);
            o.AppUserID = user.ID;
            o.AppUser = user;
            _appUserService.DetachEntity(user);

            Product p = new Product();
            foreach (var item in cart.CartProductList)
            {
                p = _productService.GetByID(item.ID);

                o.OrderDetails.Add(new OrderDetail
                {
                    ProductID = p.ID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
                _productService.DetachEntity(p);
            }
            _orderService.Add(o);

            return Redirect("/Home/Index");
        }
    }
}