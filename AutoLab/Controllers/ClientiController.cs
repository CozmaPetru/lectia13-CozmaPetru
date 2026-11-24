using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoLab.Models;
using AutoLab.Data;

namespace AutoLab.Controllers
{
    public class ClientiController : Controller
    {
        private AutoDbContext db;

        public ClientiController(AutoDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Inregistrare(int automobilId)
        {
            ContClient cont = new ContClient();
            cont.TipClient = "Persoană fizică";
            if (automobilId > 0)
            {
                cont.AutomobileDorite = new List<int>();
                cont.AutomobileDorite.Add(automobilId);
            }
            PregatesteListele();
            return View(cont);
        }

        [HttpPost]
        public IActionResult Inregistrare(ContClient cont)
        {
            // Reguli care nu se pot scrie cu atribute: le verifică acțiunea.
            if (!cont.AcordTermeni)
            {
                ModelState.AddModelError("AcordTermeni", "Bifează acordul cu termenii de utilizare.");
            }
            if (cont.TipClient == "Persoană juridică" && string.IsNullOrEmpty(cont.Observatii))
            {
                ModelState.AddModelError("", "Pentru o persoană juridică, scrie la „Observații” denumirea companiei.");
            }

            if (!ModelState.IsValid)
            {
                PregatesteListele();
                return View(cont);
            }
            ViewBag.AutomobileAlese = NumeleAutomobilelor(cont.AutomobileDorite);
            return View("Confirmare", cont);
        }

        // Listele de opțiuni pentru formular. Se pregătesc la fiecare afișare a lui.
        private void PregatesteListele()
        {
            ViewBag.Localitati = new SelectList(Optiuni.Localitati);
            ViewBag.TipuriClient = Optiuni.TipuriClient;

            List<SelectListItem> automobile = new List<SelectListItem>();
            foreach (Automobil automobil in db.Automobile)
            {
                SelectListItem element = new SelectListItem();
                element.Value = automobil.Id.ToString();
                element.Text = automobil.Marca + " " + automobil.Modelul + ", " + automobil.AnFabricatie;
                automobile.Add(element);
            }
            ViewBag.Automobile = automobile;
        }

        // Transformă lista de Id-uri primită din formular în denumiri.
        private List<string> NumeleAutomobilelor(List<int> iduri)
        {
            List<string> nume = new List<string>();
            if (iduri == null)
            {
                return nume;
            }
            foreach (int id in iduri)
            {
                Automobil automobil = db.Automobile.Find(id);
                if (automobil != null)
                {
                    nume.Add(automobil.Marca + " " + automobil.Modelul);
                }
            }
            return nume;
        }
    }
}
