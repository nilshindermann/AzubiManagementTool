using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für einen Besuch eines Lernenden von einer Kontaktperson
    /// </summary>
    public class Besuch : IDataErrorInfo
    {
        public string Error => string.Empty;
        public string this[string name]
        {
            get
            {
                if (name == nameof(Datum) && Datum == null)
                {
                    return "Das Datum fehlt";
                }
                else if (name == nameof(Lernender) && Lernender == null)
                {
                    return "Der Lernende fehlt";
                }
                else if (name == nameof(Kontaktperson) && Kontaktperson == null)
                {
                    return "Die Kontaktperson fehlt";
                }
                else if (name == nameof(Grund) && string.IsNullOrWhiteSpace(Grund))
                {
                    return "Der Grund fehlt";
                }
                return string.Empty;
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        public Lernende? Lernender { get; set; }

        public Kontaktperson? Kontaktperson { get; set; }

        public string Grund { get; set; } = string.Empty;
    }
}