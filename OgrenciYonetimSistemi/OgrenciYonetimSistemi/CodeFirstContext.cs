using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OgrenciYonetimSistemi
{
    class CodeFirstContext : DbContext
    {
        public DbSet<Fakulte> Fakultes { get; set; }
        public DbSet<Bolum> Bolums { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Ders> Derss { get; set; }
        public DbSet<OgrenciDers> OgrenciDerss { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
