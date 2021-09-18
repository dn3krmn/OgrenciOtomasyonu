using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimSistemi
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int BolumID { get; set; }
        public virtual Bolum Bolum { get; set; }
        public ICollection<OgrenciDers> OgrenciDerss { get; set; }
    }
}
