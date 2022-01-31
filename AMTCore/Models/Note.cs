using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für eine Note eines Lernenden in einem Modul
    /// </summary>
    public class Note : IDataErrorInfo
    {
        public string Error => string.Empty;
        public string this[string name]
        {
            get
            {
                if (name == nameof(Lernender) && Lernender == null)
                {
                    return "Lernender fehlt";
                }
                else if (name == nameof(Wert) && (Wert < 1.0 || Wert > 6.0))
                {
                    return "Illegaler Notenwert";
                }
                else if (name == nameof(Gewicht) && Gewicht < 0)
                {
                    return "Gewicht kann nicht negativ sein";
                }
                else if (name == nameof(Modul) && (Modul < 100 || Modul > 999))
                {
                    return "Falsches Format für Modul";
                }
                return string.Empty;
            }
        }

        [Key]
        public int Id { get; set; }
        public Lernende? Lernender { get; set; }

        [Required]
        public float Wert { get; set; }

        [Required]
        public float Gewicht { get; set; } = 1.0F;

        [Required]
        public int Modul { get; set; }

        [Required]
        public bool IstMP { get; set; } = false;
    }
}
