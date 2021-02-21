using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtamasyon.Models.Siniflar
{
    public class Yapilacaklar
    {
        [Key]
        public int YapilacakID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string YapilacakBaslik { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
    }
}