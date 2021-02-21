using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class GaleriController : Controller
    {
        Context dr = new Context();
        // GET: Galeri
        public ActionResult Index()
        {
            var urn = dr.Uruns.ToList();
            return View(urn);
        }
    }
}