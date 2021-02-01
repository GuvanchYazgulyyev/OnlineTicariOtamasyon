using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;

namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context dr = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var depgetr = dr.Departmanlars.ToList();  // Hata  Alıyorum
            return View(depgetr);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkle(Departmanlar d)
        {
            dr.Departmanlars.Add(d);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}