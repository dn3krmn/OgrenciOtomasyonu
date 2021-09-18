using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimSistemi
{
    public class Bolum
    {
        [Key]
        public int BolumID { get; set; }
        public string BolumAd { get; set; }
        public int FakulteID { get; set; }
        public virtual Fakulte Fakulte { get; set; }
        public virtual ICollection<Ogrenci> Ogrencis { get; set; }
        public virtual ICollection<Ders> Derss { get; set; }
    }
}
