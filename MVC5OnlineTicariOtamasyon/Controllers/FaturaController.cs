using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context dr = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var fat = dr.Faturas.ToList();
            return View(fat);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            dr.Faturas.Add(f);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fgetr = dr.Faturas.Find(id);
            return View("FaturaGetir", fgetr);
        }

        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fat = dr.Faturas.Find(f.FaturaID);
            fat.FaturaSeriNo = f.FaturaSeriNo;
            fat.FaturaSiraNo = f.FaturaSiraNo;
            fat.Tarih = f.Tarih;
            fat.Saat = f.Saat;
            fat.TeslimAlan = f.TeslimAlan;
            fat.TeslimEden = f.TeslimEden;
            fat.VergiDairesi = f.VergiDairesi;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var fdetay = dr.FaturaKalems.Where(h => h.Faturaid == id).ToList();
            return View(fdetay);
        }

        // Fatura Kalem Ekleme Kısmı
        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            return View();
        }

    
        public ActionResult FaturaKalemEkle(FaturaKalem f)
        {
            dr.FaturaKalems.Add(f);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}