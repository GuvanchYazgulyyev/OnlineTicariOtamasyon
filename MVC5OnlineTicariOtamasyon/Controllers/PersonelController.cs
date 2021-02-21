using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context dr
            = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var pers = dr.Personels.Where(a => a.Durum == true).ToList();
            return View(pers);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in dr.Departmanlars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            p.Durum = true;
            dr.Personels.Add(p);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var persl = dr.Personels.Find(id);
            persl.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {

            List<SelectListItem> deger1 = (from x in dr.Departmanlars.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var pgetr = dr.Personels.Find(id);
            return View("PersonelGetir", pgetr);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var prguncel = dr.Personels.Find(p.PersonelID);
            prguncel.PersonelAd = p.PersonelAd;
            prguncel.PersonelSoyad = p.PersonelSoyad;
            prguncel.PersonelGorsel = p.PersonelGorsel;
            prguncel.PersonelTel = p.PersonelTel;
            prguncel.Departmanid = p.Departmanid;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelDetay()
        {
            var deger = dr.Personels.ToList();
            return View(deger);
        }
    }
}