namespace AutoLab.Models
{
    public static class Baza
    {
        private static int urmatorulId = 9;

        // Lecția 12: filialele dealerului.
        public static List<Filiala> Filiale = new List<Filiala>
        {
            new Filiala { Id = 1, Denumire = "Cahul" },
            new Filiala { Id = 2, Denumire = "Chișinău" },
            new Filiala { Id = 3, Denumire = "Bălți" }
        };

        public static List<Automobil> Automobile = new List<Automobil>
        {
            new Automobil
            {
                Id = 1, FilialaId = 1, Marca = "Dacia", Modelul = "Logan", AnFabricatie = 2019,
                Pret = 128500m, DataInmatricularii = new DateTime(2019, 4, 12),
                Kilometraj = 86400, Combustibil = "Benzină", Caroserie = "Sedan",
                EsteDisponibil = true,
                Descriere = "Un singur proprietar. Revizii la reprezentanță."
            },
            new Automobil
            {
                Id = 2, FilialaId = 2, Marca = "Volkswagen", Modelul = "Golf", AnFabricatie = 2017,
                Pret = 189990.50m, DataInmatricularii = new DateTime(2017, 9, 3),
                Kilometraj = 142000, Combustibil = "Motorină", Caroserie = "Hatchback",
                EsteDisponibil = true,
                Descriere = "Motor 1.6 TDI, cutie manuală."
            },
            new Automobil
            {
                Id = 3, FilialaId = 1, Marca = "Toyota", Modelul = "Corolla", AnFabricatie = 2026,
                Pret = 465000m, DataInmatricularii = new DateTime(2026, 8, 21),
                Kilometraj = null, Combustibil = "Hibrid", Caroserie = "Sedan",
                EsteDisponibil = true,
                Descriere = "Automobil nou, hibrid."
            },
            new Automobil
            {
                Id = 4, FilialaId = 3, Marca = "Skoda", Modelul = "Octavia", AnFabricatie = 2020,
                Pret = 254300m, DataInmatricularii = new DateTime(2020, 2, 14),
                Kilometraj = 98750, Combustibil = "Motorină", Caroserie = "Break",
                EsteDisponibil = false,
                Descriere = "Vândut. Se păstrează în listă pentru istoric."
            },
            new Automobil
            {
                Id = 5, FilialaId = 2, Marca = "Renault", Modelul = "Clio", AnFabricatie = 2016,
                Pret = 99800.75m, DataInmatricularii = new DateTime(2016, 6, 30),
                Kilometraj = 167300, Combustibil = "Benzină", Caroserie = "Hatchback",
                EsteDisponibil = true,
                Descriere = "Consum mic, potrivit pentru oraș."
            },
            new Automobil
            {
                Id = 6, FilialaId = 1, Marca = "Hyundai", Modelul = "Tucson", AnFabricatie = 2022,
                Pret = 398000m, DataInmatricularii = new DateTime(2022, 11, 5),
                Kilometraj = 41200, Combustibil = "Benzină", Caroserie = "SUV",
                EsteDisponibil = true,
                Descriere = "Tracțiune integrală, cameră de parcare."
            },
            new Automobil
            {
                Id = 7, FilialaId = 3, Marca = "Ford", Modelul = "Focus", AnFabricatie = 2018,
                Pret = 156450m, DataInmatricularii = new DateTime(2018, 3, 19),
                Kilometraj = 121900, Combustibil = "Benzină", Caroserie = "Hatchback",
                EsteDisponibil = false,
                Descriere = "Rezervat de un client."
            },
            new Automobil
            {
                Id = 8, FilialaId = 2, Marca = "Kia", Modelul = "Sportage", AnFabricatie = 2026,
                Pret = 512000m, DataInmatricularii = new DateTime(2026, 9, 28),
                Kilometraj = null, Combustibil = "Hibrid", Caroserie = "SUV",
                EsteDisponibil = true,
                Descriere = "Automobil nou, garanție 7 ani."
            }
        };

        public static Automobil CautaDupaId(int id)
        {
            foreach (Automobil automobil in Automobile)
            {
                if (automobil.Id == id)
                {
                    return automobil;
                }
            }
            return null;
        }

        public static void Adauga(Automobil automobil)
        {
            automobil.Id = urmatorulId;
            urmatorulId = urmatorulId + 1;
            Automobile.Add(automobil);
        }
    }
}
