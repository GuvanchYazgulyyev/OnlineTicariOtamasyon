using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;
using PagedList;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class UrunController : Controller
    {

        Context dr = new Context();
        // GET: Urun
        public ActionResult Index(int sayfa=1)
        {
            var urngtr = dr.Uruns.Where(y => y.Durum == true).ToList().ToPagedList(sayfa, 7);
            return View(urngtr);
        }

        // Arama Yapmak için greken Kodlar
      
        //public ActionResult Index(string p)
        //{
        //    var urngtr = from x in dr.Uruns select x;
        //    if (!string.IsNullOrEmpty(p))
        //    {
        //        urngtr = urngtr.Where(x => x.UrunAd.Contains(p));
        //    }
        //    return View(urngtr.ToList());
        //}

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
            u.Durum = true;
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

        public ActionResult UrunCiktisi()
        {
            var dg = dr.Uruns.ToList();
            return View(dg);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> d3 = (from x in dr.Personels.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.PersonelAd + " " + x.PersonelSoyad,
                                           Value = x.PersonelID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;
            var deger1 = dr.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            dr.SatisHarekets.Add(s);
            dr.SaveChanges();
            return RedirectToAction("Index", "Satislar");
        }

    }
}