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
            optionsBuilder.UseSqlServer("Data Source=LWZO-PC,49170;Initial Catalog=AMT;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lernende>().HasComment("Auszubildende im Ausbildungszentrum Zürcher Oberland");
            modelBuilder.Entity<Lehrfirma>().HasComment("Lehrfirmen mit Adresse");
            modelBuilder.Entity<Kontaktperson>().HasComment("Kontaktpersonen der Lernenden bei Lehrfirmen");
            modelBuilder.Entity<Besuch>().HasComment("Besuche von Kontaktpersonen");
            modelBuilder.Entity<Note>().HasComment("Noten der Lernenden in den Modulen");
        }
    }
}
