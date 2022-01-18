using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    public class Lehrfirma
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Adresse { get; set; }
        public string? Ort { get; set; }
        public string? Plz { get; set; }
    }
}
