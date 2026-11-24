using System.ComponentModel.DataAnnotations;

namespace AutoLab.Models
{
    public class Adresa
    {
        [Display(Name = "Orașul")]
        public string Oras { get; set; }

        [Display(Name = "Strada")]
        public string Strada { get; set; }
    }

    public class Persoana
    {
        [Display(Name = "Numele")]
        [Required(ErrorMessage = "Scrie numele.")]
        public string Nume { get; set; }

        [Display(Name = "Telefonul")]
        public string Telefon { get; set; }

        // Obiect în obiect: în formular, numele câmpului are un punct.
        public Adresa Adresa { get; set; }
    }

    // Comanda de cumpărare: are două persoane, deci aceleași câmpuri de două ori.
    public class Comanda
    {
        [Display(Name = "Automobilul")]
        public int AutomobilId { get; set; }

        [Display(Name = "Avansul, lei")]
        public decimal Avans { get; set; }

        public Persoana Cumparator { get; set; }

        public Persoana Garant { get; set; }
    }
}
