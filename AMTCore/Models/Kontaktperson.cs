using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für eine Kontaktperson einer Lehrfirma
    /// </summary>
    public class Kontaktperson : IDataErrorInfo
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
                else if (name == nameof(Email) && string.IsNullOrWhiteSpace(Email))
                {
                    return "Die E-Mail-Adresse fehlt";
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
