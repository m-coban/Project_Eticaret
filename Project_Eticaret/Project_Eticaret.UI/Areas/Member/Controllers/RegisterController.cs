using Project_Eticaret.MODEL.Entites;
using Project_Eticaret.SERVICE.Option;
using Project_Eticaret.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Eticaret.UI.Areas.Member.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Member/Register
        AppUserService _appUserService;
        public RegisterController()
        {
            _appUserService = new AppUserService();
        }

        [HttpGet]
        public ActionResult Register()
        {
            // Kayıt formunu döndürür
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser data, HttpPostedFileBase image)
        {
            // Kayıt formunu içindeki bilgilerle gönderir
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "~/Content/img/author/author_1.png";

            data.Role = Role.Member;

            _appUserService.Add(data);

            return View();
        }
    }
}