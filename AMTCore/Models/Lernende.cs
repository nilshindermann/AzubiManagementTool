using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für einen Lernenden mit vielen Informationen
    /// </summary>
    public class Lernende : IDataErrorInfo
    {
        public string Error => string.Empty;
        public string this[string name]
        {
            get
            {
                if (name == nameof(Vorname) && string.IsNullOrWhiteSpace(Vorname))
                {
                    return "Der Vorname fehlt";
                }
                else if (name == nameof(Nachname) && string.IsNullOrWhiteSpace(Nachname))
                {
                    return "Der Nachname fehlt";
                }
                else if (name == nameof(Geschlecht) && string.IsNullOrWhiteSpace(Geschlecht))
                {
                    return "Das Geschlecht fehlt";
                }
                else if (name == nameof(Email) && string.IsNullOrWhiteSpace(Email))
                {
                    return "Die E-Mail-Adresse fehlt";
                }
                else if (name == nameof(Beruf) && string.IsNullOrWhiteSpace(Beruf))
                {
                    return "Die Fachrichtung fehlt";
                }
                else if (name == nameof(Lehrfirma) && Lehrfirma == null)
                {
                    return "Die Lehrfirma fehlt";
                }
                return string.Empty;
            }
        }

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
