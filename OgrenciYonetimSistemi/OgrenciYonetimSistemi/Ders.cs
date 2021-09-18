using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimSistemi
{
    public class Ders
    {
        [Key]
        public int DersID { get; set; }
        public string DersAdi { get; set; }
        public int BolumID { get; set; }
        public virtual Bolum Bolum { get; set; }
        public ICollection<OgrenciDers> OgrenciDerss { get; set; }
    }
}
