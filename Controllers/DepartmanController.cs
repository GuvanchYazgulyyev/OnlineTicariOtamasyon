using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context dr = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var depgetr = dr.Departmanlars.Where(x => x.Durum == true).ToList();
            return View(depgetr);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkle(Departmanlar d)
        {
            d.Durum = true;
            dr.Departmanlars.Add(d);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var depsl = dr.Departmanlars.Find(id);
            depsl.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var depgtr = dr.Departmanlars.Find(id);
            return View("DepartmanGetir", depgtr);
        }

        public ActionResult DepartmanGuncelle(Departmanlar d)
        {
            var depguncl = dr.Departmanlars.Find(d.DepartmanID);
            depguncl.DepartmanAd = d.DepartmanAd;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var depdetay = dr.Personels.Where(g => g.Departmanid == id).ToList();
            var dep = dr.Departmanlars.Where(f => f.DepartmanID == id).Select(d => d.DepartmanAd).FirstOrDefault();
            ViewBag.d = dep;
            return View(depdetay);
        }

        public ActionResult DepartmanPerSatis(int id)
        {
            var depersat = dr.SatisHarekets.Where(f => f.Personelid == id).ToList();
            var sepadsod = dr.Personels.Where(k => k.PersonelID == id).
                Select(f => f.PersonelAd + " " + f.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = sepadsod;
            return View(depersat);
        }
    }
}