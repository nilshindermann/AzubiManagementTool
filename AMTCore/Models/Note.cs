using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    public class Note
    {
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
