using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5OnlineTicariOtamasyon.Models.Siniflar
{
    public class Departmanlar
    {
        [Key]
        public int DepartmanID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(35)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
        
    }
}