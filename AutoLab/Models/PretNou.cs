using System.ComponentModel.DataAnnotations;

namespace AutoLab.Models
{
    // Un rând din tabelul de prețuri. Conține doar ce se modifică pe această pagină.
    public class PretNou
    {
        public int Id { get; set; }

        public string Denumire { get; set; }

        [Range(1, 10000000, ErrorMessage = "Prețul trebuie să fie pozitiv.")]
        public decimal Pret { get; set; }
    }
}
