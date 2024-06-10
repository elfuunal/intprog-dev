using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace intprogödev.Models.Data
{
    public class OgrenciDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=ELIFUNAL\SQLEXPRESS;Initial Catalog=intprog;Integrated Security=true;TrustServerCertificate=true");
        }


        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<OgrenciDers> OgrenciDersler { get; set; }
    }
}
