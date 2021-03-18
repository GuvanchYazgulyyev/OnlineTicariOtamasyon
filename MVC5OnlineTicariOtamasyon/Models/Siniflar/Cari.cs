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
        [StringLength(22, ErrorMessage = "En Fazla 22 Karakter Yazabilirsiniz.")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage ="En Fazla 15 Karakter Yazabilirsiniz.")]
        [Required]
        public string CariTel { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Yazabilirsiniz.")]
        public string CariUnvan { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25, ErrorMessage = "En Fazla 25 Karakter Yazabilirsiniz.")]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(40, ErrorMessage = "En Fazla 40 Karakter Yazabilirsiniz.")]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}