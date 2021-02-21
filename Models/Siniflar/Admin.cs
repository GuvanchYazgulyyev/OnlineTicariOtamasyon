using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtamasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdimnID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(18)]
        public string KullaniciAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(18)]
        public string Sifre { get; set; }


        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }
    }
}