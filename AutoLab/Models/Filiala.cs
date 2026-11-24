using System.ComponentModel.DataAnnotations;

namespace AutoLab.Models
{
    // O filială a dealerului. Are mai multe automobile.
    public class Filiala
    {
        public int Id { get; set; }

        [Display(Name = "Filiala")]
        [Required(ErrorMessage = "Scrie denumirea filialei.")]
        [StringLength(40, ErrorMessage = "Denumirea are cel mult 40 de caractere.")]
        public string Denumire { get; set; }

        // Navigarea în sens invers: automobilele filialei.
        public List<Automobil> Automobile { get; set; }
    }
}
