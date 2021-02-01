using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtamasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(35)]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(35)]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(35)]
        public string PersonelTel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string PersonelGorsel { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public Departmanlar Departmanlar { get; set; }


    }
}