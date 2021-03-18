using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5OnlineTicariOtamasyon.Models.Siniflar;
namespace MVC5OnlineTicariOtamasyon.Controllers
{
    public class MuteriPanelController : Controller
    {

        // GET: MuteriPanel
        Context dr = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var deger = dr.Caris.FirstOrDefault(k => k.CariMail == mail);
            ViewBag.m = mail;
            return View(deger);
        }
        // Önemli Sorgu Burada  Kişinin Mail adresine Gore işlem yaptırır.
        // Yani siteme giren kullanının mail adresine göre ilgili id yi atamış olduk.

        public ActionResult Sparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = dr.Caris.Where(k => k.CariMail == mail.ToString()).Select(l => l.CariID).FirstOrDefault();
            // Sparişlerimi görebilmek için ise aşagıdaki kod komutu kullanılır.
            var deger = dr.SatisHarekets.Where(g => g.Cariid == id).ToList();
            return View(deger);
        }
    }
}