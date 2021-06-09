using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class LoginController : Controller
    {

        AppUserRepository _apRep;
        public LoginController()
        {
            _apRep = new AppUserRepository();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            AppUser user = _apRep.FirstOrDefault(x => x.UserName == appUser.UserName);

            if (user == null)
            {
                ViewBag.KullaniciYok = "Kullanıcı bulunamadı";
                return View();
            }

            string decrypted = PasswordHasher.DeCrypt(user.Password);

            if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.Admin)
            {
                Session["admin"] = user;
                return RedirectToAction("UserList", "AppUser", new { Area = "Admin" });
            }

            else if (appUser.Password == decrypted && user.Role == ENTITIES.Enums.UserRole.Member)
            {
                if (!user.Active)
                {
                    return AktifKontrol();
                }
                Session["member"] = user;
                return RedirectToAction("ShoppingList", "Shopping");
            }

            ViewBag.KullaniciYok = "Kullanıcı bulunamadı";
            return View();
        }

        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Hesabınız aktif değil. Lütfen emailinizi kontrol ediniz.";
            return View("Login");
        }
    }
}