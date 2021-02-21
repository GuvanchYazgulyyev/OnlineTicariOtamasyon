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
        [StringLength(35, ErrorMessage = "En Fazla 35 Karakter Yazabilirsiniz.")]
        [Required]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(35, ErrorMessage = "En Fazla 35 Karakter Yazabilirsiniz.")]
        [Required]
        public string PersonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En Fazla 15 Karakter Yazabilirsiniz.")]
        [Required]
        public string PersonelTel { get; set; }

        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Yazabilirsiniz.")]
        [Column(TypeName = "Varchar")]
        [Required]
        public string PersonelMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string PersonelGorsel { get; set; }
        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int Departmanid { get; set; }

        public virtual Departmanlar Departmanlar { get; set; }


    }
}