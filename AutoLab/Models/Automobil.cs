using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AutoLab.Models
{
    public class Automobil
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Indică marca automobilului.")]
        [StringLength(30, ErrorMessage = "Marca are cel mult 30 de caractere.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Indică modelul automobilului.")]
        [StringLength(30, ErrorMessage = "Modelul are cel mult 30 de caractere.")]
        public string Modelul { get; set; }

        [Display(Name = "Anul fabricației")]
        [Required(ErrorMessage = "Scrie anul fabricației.")]
        [Range(1990, 2026, ErrorMessage = "Anul trebuie să fie între 1990 și 2026.")]
        public int AnFabricatie { get; set; }

        [Display(Name = "Prețul")]
        [Required(ErrorMessage = "Scrie prețul.")]
        [UIHint("Pret")]
        [Precision(10, 2)]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Pret { get; set; }

        [Display(Name = "Data înmatriculării")]
        [Required(ErrorMessage = "Alege data înmatriculării.")]
        [DataType(DataType.Date)]
        public DateTime DataInmatricularii { get; set; }

        [Display(Name = "Kilometrajul, km")]
        [DisplayFormat(DataFormatString = "{0:N0}", NullDisplayText = "automobil nou")]
        public int? Kilometraj { get; set; }

        [Display(Name = "Combustibilul")]
        [Required(ErrorMessage = "Alege tipul de combustibil.")]
        [StringLength(20)]
        public string Combustibil { get; set; }

        [Display(Name = "Caroseria")]
        [Required(ErrorMessage = "Alege tipul caroseriei.")]
        [StringLength(20)]
        public string Caroserie { get; set; }

        [Display(Name = "Disponibil pentru vânzare")]
        public bool EsteDisponibil { get; set; }

        [Display(Name = "Descrierea")]
        [DataType(DataType.MultilineText)]
        public string Descriere { get; set; }

        // Numele fișierului din wwwroot/incarcari. Fișierul stă pe disc, nu în baza de date.
        [ScaffoldColumn(false)]
        [StringLength(60)]
        public string Fotografie { get; set; }

        // Lecția 12. Cheia străină: Id-ul filialei din tabelul Filiale.
        [Display(Name = "Filiala")]
        [Required(ErrorMessage = "Alege filiala.")]
        [ScaffoldColumn(false)]
        public int FilialaId { get; set; }

        // Proprietatea de navigare: filiala însăși. O completează Include.
        public Filiala Filiala { get; set; }
    }
}
