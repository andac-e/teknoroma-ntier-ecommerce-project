using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using Project.WEBUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class RegisterController : Controller
    {

        AppUserRepository _apRep;
        UserProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new UserProfileRepository();
        }

        // GET: Register
        public ActionResult RegisterNow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNow(AppUserVM apvm)
        {
            AppUser user = apvm.AppUser;
            UserProfile profile = apvm.Profile;

            user.Password = PasswordHasher.Crypt(user.Password);

            if (_apRep.Any(x => x.UserName == user.UserName))
            {
                ViewBag.KullaniciVar = "Bu kullanıcı ismi daha önce alınmış.";
                return View();
            }
            else if (_apRep.Any(x => x.Email == user.Email))
            {
                ViewBag.KullaniciVar = "Bu email daha önceden kullanılmış. Lütfen yeni bir email giriniz.";
                return View();
            }

            //Başarılı register'da mail gönderme

            string aktivasyonMail = "Tebrikler! Hesabınız oluşturuldu. Hesabınızı aktive etmek için https://localhost:44335/Register/Activation/" + user.ActivationCode + " linkine tıklayabilirsiniz.";

            MailService.Send(user.Email, body: aktivasyonMail, subject: "Teknoroma'ya Hoşgeldiniz!");

            _apRep.Add(user); //Profile eklemek için önce AppUser ekleyip ID'si oluşturulmalı. 

            if (!string.IsNullOrEmpty(profile.FirstName) || !string.IsNullOrEmpty(profile.LastName) || !string.IsNullOrEmpty(profile.Address) || !string.IsNullOrEmpty(profile.TCNO))
            {
                profile.ID = user.ID;
                _proRep.Add(profile);
            }

            return View("RegisterOk");

        }

        public ActionResult Activation(Guid id)
        {
            AppUser aktifEdilecek = _apRep.FirstOrDefault(x => x.ActivationCode == id);

            if (aktifEdilecek != null)
            {
                aktifEdilecek.Active = true;
                _apRep.Update(aktifEdilecek);
                TempData["HesapAktif"] = "Hesabınız aktif hale getirilmiştir. İyi alışverişler dileriz...";
                return RedirectToAction("Login", "Home");
            }
            TempData["HesapAktif"] = "Hesabınız bulunamadı.";
            return RedirectToAction("Login", "Home");
        }

        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}