using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class YapilacaklarController : Controller
    {
        Context dr = new Context();
        // GET: Yapilacaklar
        public ActionResult Index()
        {
            var de1 = dr.Caris.Count().ToString();
            ViewBag.d1 = de1;

            var de2 = dr.Uruns.Count().ToString();
            ViewBag.d2 = de2;

            var de3 = dr.Kategoris.Count().ToString();
            ViewBag.d3 = de3;

            var de4 = dr.Personels.Count().ToString();
            ViewBag.d4 = de4;

            return View();
        }
    }
}