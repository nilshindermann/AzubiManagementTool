using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    /// <summary>
    /// Model-Klasse für eine Lehrfirma mit Adresse
    /// </summary>
    public class Lehrfirma : IDataErrorInfo
    {
        public string Error => string.Empty;
        public string this[string name]
        {
            get
            {
                if (name == nameof(Name) && string.IsNullOrWhiteSpace(Name))
                {
                    return "Der Firmenname fehlt";
                }
                return string.Empty;
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Adresse { get; set; }
        public string? Ort { get; set; }
        public string? Plz { get; set; }
    }
}
