using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtamasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(22)]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string CariSoyad { get; set; }


        public int CariTel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariUnvan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string CariMail { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}