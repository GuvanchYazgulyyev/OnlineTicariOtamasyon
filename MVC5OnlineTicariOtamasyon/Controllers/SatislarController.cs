using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class SatislarController : Controller
    {
        Context dr = new Context();
        // GET: Satislar
        public ActionResult Index()
        {
            var sat = dr.SatisHarekets.ToList();
            return View(sat);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            //urunlerin versini eklemek ve çekmek için kyllanılır
            List<SelectListItem> d1 = (from x in dr.Uruns.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.UrunAd,
                                           Value = x.UrunID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            //Carilerin versini eklemek ve çekmek için kyllanılır
            List<SelectListItem> d2 = (from x in dr.Caris.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CariAd + " " + x.CariSoyad,
                                           Value = x.CariID.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2;


            //Personel versini eklemek ve çekmek için kyllanılır
            List<SelectListItem> d3 = (from x in dr.Personels.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.PersonelAd + " " + x.PersonelSoyad,
                                           Value = x.PersonelID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            dr.SatisHarekets.Add(s);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {

            //urunlerin versini eklemek ve çekmek için kyllanılır
            List<SelectListItem> d1 = (from x in dr.Uruns.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.UrunAd,
                                           Value = x.UrunID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            //Carilerin versini eklemek ve çekmek için kyllanılır
            List<SelectListItem> d2 = (from x in dr.Caris.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.CariAd + " " + x.CariSoyad,
                                           Value = x.CariID.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2;


            //Personel versini eklemek ve çekmek için kyllanılır
            List<SelectListItem> d3 = (from x in dr.Personels.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.PersonelAd + " " + x.PersonelSoyad,
                                           Value = x.PersonelID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            var satgtr = dr.SatisHarekets.Find(id);
            return View("SatisGetir", satgtr);
        }

        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var sgunc = dr.SatisHarekets.Find(s.SatisID);
            sgunc.Cariid = s.Cariid;
            sgunc.Adet = s.Adet;
            sgunc.Fiyat = s.Fiyat;
            sgunc.Personelid = s.Personelid;
            sgunc.Toplam = s.Toplam;
            //sgunc.Tarih = s.Tarih;
            sgunc.Urunid = s.Urunid;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var d = dr.SatisHarekets.Where(f => f.SatisID == id).ToList();
            return View(d);
        }
    }
}