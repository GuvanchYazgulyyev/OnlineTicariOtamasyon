using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtamasyon.Models.Siniflar
{
    public class UrnDetay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string urunad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string urunbilgi { get; set; }
    }
}