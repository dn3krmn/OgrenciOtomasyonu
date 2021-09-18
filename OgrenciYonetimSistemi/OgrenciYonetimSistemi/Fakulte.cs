using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciYonetimSistemi
{
    public class Fakulte
    {
        [Key]
        public int FakulteID { get; set; }
        public string FakulteAd { get; set; }
        public ICollection<Bolum> Bolums { get; set; }
    }
}
