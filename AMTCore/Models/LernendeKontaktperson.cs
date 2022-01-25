using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    /// <summary>
    /// Aktuell unbenutzte Klasse.
    /// Wäre zum Zuordnen von Kontaktpersonen
    /// </summary>
    public class LernendeKontaktperson
    {
        [Key]
        public int Id { get; set; }
        public Lernende? Lernende { get; set; }
        public Kontaktperson? Kontaktperson { get; set; }
    }
}
