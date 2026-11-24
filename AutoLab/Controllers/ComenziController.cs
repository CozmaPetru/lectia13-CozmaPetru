using Microsoft.AspNetCore.Mvc;
using AutoLab.Models;
using AutoLab.Data;

namespace AutoLab.Controllers
{
    public class ComenziController : Controller
    {
        private AutoDbContext db;

        public ComenziController(AutoDbContext db)
        {
            this.db = db;
        }

        // Pasul 2. Formularul cu obiecte în obiect.
        [HttpGet]
        public IActionResult Noua()
        {
            return View(new Comanda());
        }

        [HttpPost]
        public IActionResult Noua(Comanda comanda)
        {
            if (!ModelState.IsValid)
            {
                return View(comanda);
            }
            return View("Confirmare", comanda);
        }

        // Pasul 2. Din același formular, doar datele garantului.
        [HttpPost]
        public IActionResult DoarGarant([Bind(Prefix = "Garant")] Persoana persoana)
        {
            ViewBag.Rol = "Garantul";
            return View("Persoana", persoana);
        }

        // Experiment: doi parametri de același tip, cu și fără prefix în formular.
        [HttpGet]
        public IActionResult DouaPersoane()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DouaPersoane(Persoana cumparator, Persoana garant)
        {
            ViewBag.Cumparator = cumparator;
            ViewBag.Garant = garant;
            ModelState.Clear();
            return View();
        }
    }
}
