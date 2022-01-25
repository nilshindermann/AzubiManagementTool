using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für einen Besuch eines Lernenden von einer Kontaktperson
    /// </summary>
    public class Besuch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public Lernende? Lernender { get; set; }

        public Kontaktperson? Kontaktperson { get; set; }

        public string Grund { get; set; } = string.Empty;
    }
}