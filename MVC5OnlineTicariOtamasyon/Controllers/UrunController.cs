using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {

        Context dr = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urngtr = dr.Uruns.Where(y => y.Durum == true).ToList();
            return View(urngtr);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> d1 = (from x in dr.Kategoris.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.KategoriAd,
                                           Value = x.KategoriID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            dr.Uruns.Add(u);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        // Burada ise once tablodan verileri buluyor ve sonra Remove komutu ile tablodaki veiyi siliyor.
        public ActionResult UruniSil(int id)
        {
            var urnsil = dr.Uruns.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> d1 = (from x in dr.Kategoris.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.KategoriAd,
                                           Value = x.KategoriID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            var urngetr = dr.Uruns.Find(id);
            return View("UrunGetir", urngetr);
        }

        // Verileri bulduktan sonra alttaki komutlarla güncelleme yapılır

        public ActionResult UrunGuncelle(Urun u)
        {
            var urng = dr.Uruns.Find(u.UrunID);
            urng.UrunAd = u.UrunAd;
            urng.Marka = u.Marka;
            urng.Stok = u.Stok;
            urng.AlisFiyat = u.AlisFiyat;
            urng.SatisFiyat = u.SatisFiyat;
            urng.Durum = u.Durum;
            urng.UrunGorsel = u.UrunGorsel;
            urng.Kategoriid = u.Kategoriid;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}