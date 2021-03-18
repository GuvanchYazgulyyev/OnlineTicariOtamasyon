using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;
using System.Web.Security;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class LoginController : Controller
    {
        Context dr = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cari c)
        {
            dr.Caris.Add(c);
            dr.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult MusteriGiris1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriGiris1(Cari musteri)
        {
            var deger = dr.Caris.FirstOrDefault(k => k.CariMail == musteri.CariMail
            && k.CariSifre == musteri.CariSifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.CariMail, false);
                Session["CariMail"] = deger.CariMail.ToString();
                return RedirectToAction("Index", "MuteriPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }

            
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin( Admin a)
        {
            var deger = dr.Admins.FirstOrDefault(f => f.KullaniciAd == a.KullaniciAd && f.Sifre==a.Sifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.KullaniciAd, false);
                Session["KullaniciAd"] = deger.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}