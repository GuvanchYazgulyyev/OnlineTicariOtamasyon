using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class istatistikController : Controller
    {
        Context dr = new Context();
        // GET: istatistik
        public ActionResult Index()
        {
            var is1 = dr.Caris.Count().ToString();
            ViewBag.d1 = is1;

            var is2 = dr.Uruns.Count().ToString();
            ViewBag.d2 = is2;

            var is3 = dr.Personels.Count().ToString();
            ViewBag.d3 = is3;

            var is4 = dr.Kategoris.Count().ToString();
            ViewBag.d4 = is4;

            var is5 = dr.Uruns.Sum(h => h.Stok).ToString();
            ViewBag.d5 = is5;

            var is6 = (from x in dr.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = is6;

            var is7 = dr.Uruns.Count(h => h.Stok <= 10).ToString();
            ViewBag.d7 = is7;

            var is8 = (from x in dr.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = is8;

            var is9 = (from x in dr.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = is9;

            var is10 = dr.Uruns.Count(h => h.UrunAd == "Telefon").ToString();
            ViewBag.d10 = is10;

            var is11 = dr.Uruns.Count(h => h.UrunAd == "Leptop").ToString();
            ViewBag.d11 = is11;

            var is12 = dr.Uruns.GroupBy(x => x.Marka).OrderByDescending(k => k.Count()).
                Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = is12;

            var is13 = dr.Uruns.Where(u => u.UrunID == (dr.SatisHarekets.GroupBy(x => x.Urunid).
              OrderByDescending(f => f.Count()).Select(g => g.Key).FirstOrDefault())).
              Select(e => e.UrunAd).FirstOrDefault();
            ViewBag.d13 = is13;

            var is14 = dr.SatisHarekets.Sum(x => x.Toplam).ToString();
            ViewBag.d14 = is14;

            DateTime bugun = DateTime.Today;
            var is15 = dr.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = is15;


            var is16 = dr.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.Toplam).ToString();
            ViewBag.d16 = is16;

            return View();
        }

        public ActionResult KolayTablo()
        {
            var sorgu = from x in dr.Caris
                        group x by x.CariSehir into g
                        select new GrupSinif
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Tablo1()
        {
            var sorgu2 = from x in dr.Personels
                         group x by x.Departmanlar.DepartmanAd into g

                         select new GrupSinif2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var deger = dr.Caris.Where(x => x.Durum == true).ToList();
            return PartialView(deger);
        }


        public PartialViewResult Partial3()
        {
            var deger = dr.Uruns.Where(g => g.Durum == true).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in dr.Uruns
                         group x by x.Marka into g

                         select new GrupSinif3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}