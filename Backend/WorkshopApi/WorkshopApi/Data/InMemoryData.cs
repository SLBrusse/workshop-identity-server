using WorkshopApi.Models;

namespace WorkshopApi.Data
{
    public class InMemoryData
    {
        public static List<Leerling> Leerlingen = new()
        {
            new Leerling { Naam = "Piet", Cijfer = 7, Informatie = "heeft 2 benen 1 arm" },
            new Leerling { Naam = "Sanne", Cijfer = 9, Informatie = "draagt een bril" },
            new Leerling { Naam = "Ali", Cijfer = 6, Informatie = "heeft een groene jas" }
        };

        public static List<Docent> Docenten = new()
        {
            new Docent { Naam = "Mevrouw Jansen" },
            new Docent { Naam = "Meneer De Vogel" },
            new Docent { Naam = "Meneer Bakker" }
        };

        public static List<Beheerder> Beheerders = new()
        {
            new Beheerder { Naam = "Admin 1" },
            new Beheerder { Naam = "Admin 2" },
            new Beheerder { Naam = "Admin 3" }
        };

        public static List<Les> Lessen = new()
        {
            new Les { Lokaal = "B2.30", Vak = "ICT" },
            new Les { Lokaal = "A1.10", Vak = "Wiskunde" },
            new Les { Lokaal = "C3.50", Vak = "Biologie" }
        };
    }
}
