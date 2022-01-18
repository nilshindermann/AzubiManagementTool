using AMTCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AMTCore.Data
{
    public class AMTContext : DbContext
    {
        public DbSet<Lernende> Lernende { get; set; }
        public DbSet<Lehrfirma> Lehrfirmen { get; set; }
        public DbSet<Kontaktperson> Kontaktpersonen { get; set; }
        public DbSet<LernendeKontaktperson> LernendeKontaktpersonen { get; set; }
        public DbSet<Besuch> Besuche { get; set; }
        public DbSet<Note> Noten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=hind-pc\\SQLEXPRESS;Initial Catalog=AMT;Integrated Security=True");
        }
    }
}
