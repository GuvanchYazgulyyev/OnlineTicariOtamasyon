using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class CariController : Controller
    {
        Context dr = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var cgtr = dr.Caris.Where(x => x.Durum == true).ToList();
            return View(cgtr);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari c)
        {
            c.Durum = true;
            dr.Caris.Add(c);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        // Burada ise once tablodan verileri buluyor ve sonra Remove komutu ile tablodaki veiyi siliyor.
        public ActionResult CariSil(int id)
        {
            var crisil = dr.Caris.Find(id);
            crisil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var crgtr = dr.Caris.Find(id);
            return View("CariGetir", crgtr);
        }

        public ActionResult CariGuncelle(Cari p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var dd = dr.Caris.Find(p.CariID);
            dd.CariAd = p.CariAd;
            dd.CariSoyad = p.CariSoyad;
            dd.CariTel = p.CariTel;
            dd.CariUnvan = p.CariUnvan;
            dd.CariSehir = p.CariSehir;
            dd.CariMail = p.CariMail;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var msatis = dr.SatisHarekets.Where(f => f.Cariid == id).ToList();
            var ms = dr.Caris.Where(d => d.CariID == id).Select(k => k.CariAd + " " + k.CariSoyad).FirstOrDefault();
            ViewBag.cari = ms;
            return View(msatis);
        }
    }
}