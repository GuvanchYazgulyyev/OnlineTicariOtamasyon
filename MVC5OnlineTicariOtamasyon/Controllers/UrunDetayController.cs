using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context dr = new Context();

        // GET: UrunDetay
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var deger = dr.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Deger1 = dr.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Deger2 = dr.UrnDetays.Where(k => k.DetayID == 1).ToList();
            return View(cs);
        }
    }
}