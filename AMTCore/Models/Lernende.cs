using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMTCore.Models
{
    public class Lernende
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Nachname { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        [Required]
        public string Geschlecht { get; set; }

        [Required]
        public string Beruf { get; set; }

        public string? Klassenjahrgang { get; set; }
        public string? Schule { get; set; }
        public string? Schulklasse { get; set; }
        public bool BMS { get; set; }
        public int LehrfirmaId { get; set; }
        public Lehrfirma Lehrfirma { get; set; }
        public DateTime? BeginnGrundausbildung { get; set; }
        public DateTime? EndeGrundausbildung { get; set; }
    }
}
