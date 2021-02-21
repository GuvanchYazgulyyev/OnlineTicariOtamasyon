using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class KategoriController : Controller
    {

        // Burada Veritabanımızı çagırdık
        Context dr = new Context();

        // GET: Kategori
        // Ve sonra 1 tane index oluşturarak alttaki komutlarla Veritabanımızdan Kategoriler tablosunu
        // Listelemesini istedik
        public ActionResult Index()
        {
            var katgetir = dr.Kategoris.ToList();

            return View(katgetir);
        }
        // ilk program boş çalıştıgında burası çalışacak yani [HttpGet]
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            dr.Kategoris.Add(k);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        // Burada ise once tablodan verileri buluyor ve sonra Remove komutu ile tablodaki veiyi siliyor.
        public ActionResult KategoriSil(int id)
        {
            var kate = dr.Kategoris.Find(id);
            dr.Kategoris.Remove(kate);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        // Güncellemeden önce güncellenecek sayfaya verilerimizi getirmemiz gerek 
        // bunun için önce sayfadaki verileri bulmamız gerek. Bunu Finde komutu ile bulabiliriz.

        public ActionResult KategoriGetir(int id)
        {
            var katgetr = dr.Kategoris.Find(id);
            return View("KategoriGetir", katgetr);
        }

        // Verileri bulduktan sonra alttaki komutlarla güncelleme yapılır

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var katguncel = dr.Kategoris.Find(k.KategoriID);
            katguncel.KategoriAd = k.KategoriAd;
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}