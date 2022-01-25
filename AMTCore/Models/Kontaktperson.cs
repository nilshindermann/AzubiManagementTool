using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für eine Kontaktperson einer Lehrfirma
    /// </summary>
    public class Kontaktperson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Lehrfirma Lehrfirma { get; set; }

        [Required]
        [Column("Name")]
        public string Nachname { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Telefon { get; set; }
    }
}
