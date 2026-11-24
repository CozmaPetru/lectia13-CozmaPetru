namespace AutoLab.Models
{
    // Listele de valori permise pentru câmpurile cu alegere.
    public static class Optiuni
    {
        public static List<string> Combustibili = new List<string>
        {
            "Benzină", "Motorină", "Hibrid", "Electric"
        };

        public static List<string> Caroserii = new List<string>
        {
            "Sedan", "Hatchback", "Break", "SUV"
        };

        public static List<string> Localitati = new List<string>
        {
            "Cahul", "Chișinău", "Bălți", "Comrat", "Ungheni", "Altă localitate"
        };

        public static List<string> TipuriClient = new List<string>
        {
            "Persoană fizică", "Persoană juridică"
        };
    }
}
