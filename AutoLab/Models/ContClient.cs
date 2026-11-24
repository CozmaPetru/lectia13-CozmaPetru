using System.ComponentModel.DataAnnotations;

namespace AutoLab.Models
{
    // Datele formularului „Cont nou”. Nu se salvează în baza de date.
    public class ContClient
    {
        [Display(Name = "Numele și prenumele")]
        [Required(ErrorMessage = "Scrie numele și prenumele.")]
        [StringLength(60, ErrorMessage = "Numele are cel mult 60 de caractere.")]
        public string Nume { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Scrie adresa de e-mail.")]
        [EmailAddress(ErrorMessage = "Adresa de e-mail nu este corectă.")]
        public string Email { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Scrie o parolă.")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Parola are între 8 și 30 de caractere.")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Display(Name = "Confirmă parola")]
        [Required(ErrorMessage = "Scrie parola încă o dată.")]
        [Compare("Parola", ErrorMessage = "Parolele nu coincid.")]
        [DataType(DataType.Password)]
        public string ConfirmareParola { get; set; }

        [Display(Name = "Localitatea")]
        [Required(ErrorMessage = "Alege localitatea.")]
        public string Localitate { get; set; }

        [Display(Name = "Tipul clientului")]
        [Required(ErrorMessage = "Alege tipul clientului.")]
        public string TipClient { get; set; }

        [Display(Name = "Automobilele care te interesează")]
        public List<int> AutomobileDorite { get; set; }

        [Display(Name = "Vreau să primesc oferte pe e-mail")]
        public bool Newsletter { get; set; }

        [Display(Name = "Sunt de acord cu termenii de utilizare")]
        public bool AcordTermeni { get; set; }

        [Display(Name = "Observații")]
        [StringLength(300, ErrorMessage = "Observațiile au cel mult 300 de caractere.")]
        public string Observatii { get; set; }
    }
}
