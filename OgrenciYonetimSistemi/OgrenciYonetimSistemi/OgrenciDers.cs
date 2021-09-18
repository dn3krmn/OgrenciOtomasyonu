using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimSistemi
{
    public class OgrenciDers
    {
        [Key]
        public int ID { get; set; }
        public int OgrenciNo { get; set; }
        public int DersID { get; set; }
        public string Yil { get; set; }
        public string Yariyil { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Ders Ders { get; set; }
    }
}
