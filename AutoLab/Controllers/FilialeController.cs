using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoLab.Models;
using AutoLab.Data;

namespace AutoLab.Controllers
{
    // Lecția 12: filialele dealerului.
    public class FilialeController : Controller
    {
        private AutoDbContext db;

        public FilialeController(AutoDbContext db)
        {
            this.db = db;
        }

        // GET /Filiale → fiecare filială, cu automobilele ei
        public IActionResult Index()
        {
            List<Filiala> filiale = db.Filiale
                .Include(f => f.Automobile)
                .OrderBy(f => f.Denumire)
                .ToList();
            return View(filiale);
        }

        [HttpGet]
        public IActionResult Adauga()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adauga(Filiala filiala)
        {
            // Regula indexului unic, verificată înainte de salvare.
            bool exista = db.Filiale.Any(f => f.Denumire == filiala.Denumire);
            if (exista)
            {
                ModelState.AddModelError("Denumire",
                    "Există deja o filială cu această denumire.");
            }
            if (!ModelState.IsValid)
            {
                return View(filiala);
            }
            db.Filiale.Add(filiala);
            db.SaveChanges();
            TempData["Mesaj"] = "Filiala " + filiala.Denumire + " a fost adăugată.";
            return RedirectToAction("Index");
        }

        // Ștergerea protejată: întâi verificăm, apoi ștergem.
        [HttpPost]
        public IActionResult Sterge(int id)
        {
            Filiala filiala = db.Filiale.Find(id);
            if (filiala == null)
            {
                return NotFound();
            }
            bool areAutomobile = db.Automobile.Any(a => a.FilialaId == id);
            if (areAutomobile)
            {
                TempData["Eroare"] = "Filiala " + filiala.Denumire
                    + " are automobile și nu poate fi ștearsă.";
                return RedirectToAction("Index");
            }
            db.Filiale.Remove(filiala);
            db.SaveChanges();
            TempData["Mesaj"] = "Filiala " + filiala.Denumire + " a fost ștearsă.";
            return RedirectToAction("Index");
        }
    }
}
