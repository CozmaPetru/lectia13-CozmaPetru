namespace AutoLab.Models
{
    // Datele pe care acțiunea Stare le trimite browserului în format JSON.
    public class StareAutomobil
    {
        public int Id { get; set; }

        public bool EsteDisponibil { get; set; }

        public int Programari { get; set; }

        public string Ora { get; set; }
    }
}
