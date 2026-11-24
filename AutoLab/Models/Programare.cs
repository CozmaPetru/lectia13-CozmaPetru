using System.ComponentModel.DataAnnotations;

namespace AutoLab.Models
{
    // O programare la test-drive, făcută de pe pagina de detalii a unui automobil.
    public class Programare
    {
        public int Id { get; set; }

        // Cheia străină: Id-ul automobilului din tabelul Automobile.
        public int AutomobilId { get; set; }

        // Proprietatea de navigare: automobilul însuși.
        public Automobil Automobil { get; set; }

        [Display(Name = "Numele")]
        [Required(ErrorMessage = "Scrie-ți numele.")]
        [StringLength(50, ErrorMessage = "Numele are cel mult 50 de caractere.")]
        public string Nume { get; set; }

        [Display(Name = "Telefonul")]
        [Required(ErrorMessage = "Scrie numărul de telefon.")]
        [StringLength(20, ErrorMessage = "Numărul are cel mult 20 de caractere.")]
        public string Telefon { get; set; }

        [Display(Name = "Ziua test-drive-ului")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Alege ziua.")]
        public DateTime? Ziua { get; set; }
    }
}
