using System.ComponentModel.DataAnnotations;

namespace AMTCore.Models
{
    public class LernendeKontaktperson
    {
        [Key]
        public int Id { get; set; }
        public Lernende? Lernende { get; set; }
        public Kontaktperson? Kontaktperson { get; set; }
    }
}
