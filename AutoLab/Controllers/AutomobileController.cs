using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoLab.Models;
using AutoLab.Data;

namespace AutoLab.Controllers
{
    public class AutomobileController : Controller
    {
        private AutoDbContext db;
        private IWebHostEnvironment mediu;

        public AutomobileController(AutoDbContext db, IWebHostEnvironment mediu)
        {
            this.db = db;
            this.mediu = mediu;
        }

        // GET /Automobile?filialaId=2&caroserie=SUV&doarDisponibile=true&text=dacia
        public IActionResult Index(int? filialaId, string caroserie,
                                   bool doarDisponibile, string text)
        {
            List<Automobil> rezultat =
                Filtreaza(filialaId, caroserie, doarDisponibile, text);

            List<Filiala> filiale = db.Filiale.OrderBy(f => f.Denumire).ToList();
            ViewBag.Filiale = new SelectList(filiale, "Id", "Denumire", filialaId);
            ViewBag.Caroserii = new SelectList(Optiuni.Caroserii, caroserie);
            ViewBag.DoarDisponibile = doarDisponibile;
            ViewBag.Text = text;
            return View(rezultat);
        }

        // Lecția 10. GET /Automobile/Lista?caroserie=SUV → doar tabelul, fără layout
        public IActionResult Lista(int? filialaId, string caroserie,
                                   bool doarDisponibile, string text)
        {
            List<Automobil> rezultat =
                Filtreaza(filialaId, caroserie, doarDisponibile, text);
            return PartialView("_Tabel", rezultat);
        }

        // Lecția 10. GET /Automobile/Stare/3 → date în format JSON
        public IActionResult Stare(int id)
        {
            Automobil automobil = db.Automobile.Find(id);
            if (automobil == null)
            {
                return NotFound();
            }
            // Lecția 12: baza de date numără, nu bucla noastră.
            int numarProgramari = db.Programari.Where(p => p.AutomobilId == id).Count();
            StareAutomobil stare = new StareAutomobil();
            stare.Id = automobil.Id;
            stare.EsteDisponibil = automobil.EsteDisponibil;
            stare.Programari = numarProgramari;
            stare.Ora = DateTime.Now.ToString("HH:mm:ss");
            return Json(stare);
        }

        // Lecția 10. POST /Automobile/TestDrive, trimis cu fetch
        [HttpPost]
        public IActionResult TestDrive(Programare programare)
        {
            if (programare.Ziua != null && programare.Ziua.Value.Date <= DateTime.Today)
            {
                ModelState.AddModelError("Ziua", "Alege o zi începând de mâine.");
            }
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_TestDrive", programare);
            }
            db.Programari.Add(programare);
            db.SaveChanges();
            return PartialView("_TestDriveConfirmare", programare);
        }

        public IActionResult Detalii(int id)
        {
            // Find nu se combină cu Include, deci căutăm cu FirstOrDefault.
            Automobil automobil = db.Automobile
                .Include(a => a.Filiala)
                .FirstOrDefault(a => a.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        [HttpGet]
        public IActionResult Adauga()
        {
            PregatesteListele();
            return View();
        }

        [HttpPost]
        public IActionResult Adauga(Automobil automobil)
        {
            if (!ModelState.IsValid)
            {
                PregatesteListele();
                return View(automobil);
            }
            db.Automobile.Add(automobil);
            db.SaveChanges();
            TempData["Mesaj"] = "Automobilul " + automobil.Marca + " " + automobil.Modelul + " a fost adăugat.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editeaza(int id)
        {
            Automobil automobil = db.Automobile.Find(id);
            if (automobil == null)
            {
                return NotFound();
            }
            PregatesteListele();
            return View(automobil);
        }

        [HttpPost]
        public IActionResult Editeaza(Automobil automobil)
        {
            if (!ModelState.IsValid)
            {
                PregatesteListele();
                return View(automobil);
            }
            db.Automobile.Update(automobil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sterge(int id)
        {
            Automobil automobil = db.Automobile.Find(id);
            if (automobil == null)
            {
                return NotFound();
            }
            db.Automobile.Remove(automobil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ===== Lecția 11, pasul 3: masiv de valori simple =====
        // GET /Automobile/Alege → lista cu casete de bifat
        public IActionResult Alege()
        {
            List<Automobil> toate = db.Automobile.ToList();
            return View(toate);
        }

        // GET /Automobile/Compara?ids=1&ids=3 → aceeași cheie, de mai multe ori
        public IActionResult Compara(int[] ids)
        {
            List<Automobil> alese = new List<Automobil>();
            foreach (int id in ids)
            {
                Automobil automobil = db.Automobile.Find(id);
                if (automobil != null)
                {
                    alese.Add(automobil);
                }
            }
            return View(alese);
        }

        // ===== Lecția 11, pasul 4: listă de obiecte =====
        // GET /Automobile/Preturi → câte un rând editabil pentru fiecare automobil
        [HttpGet]
        public IActionResult Preturi()
        {
            List<PretNou> randuri = new List<PretNou>();
            foreach (Automobil automobil in db.Automobile)
            {
                PretNou rand = new PretNou();
                rand.Id = automobil.Id;
                rand.Denumire = automobil.Marca + " " + automobil.Modelul;
                rand.Pret = automobil.Pret;
                randuri.Add(rand);
            }
            return View(randuri);
        }

        // POST /Automobile/Preturi → [0].Id, [0].Pret, [1].Id, [1].Pret...
        [HttpPost]
        public IActionResult Preturi(List<PretNou> preturi)
        {
            if (!ModelState.IsValid)
            {
                return View(preturi);
            }
            int modificate = 0;
            foreach (PretNou rand in preturi)
            {
                Automobil automobil = db.Automobile.Find(rand.Id);
                if (automobil != null && automobil.Pret != rand.Pret)
                {
                    automobil.Pret = rand.Pret;
                    modificate = modificate + 1;
                }
            }
            db.SaveChanges();
            TempData["Mesaj"] = "Prețuri modificate: " + modificate + ".";
            return RedirectToAction("Index");
        }

        // ===== Lecția 11, pasul 7: încărcarea fișierului =====
        [HttpGet]
        public IActionResult Fotografie(int id)
        {
            Automobil automobil = db.Automobile.Find(id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        [HttpPost]
        public IActionResult Fotografie(int id, IFormFile fisier)
        {
            Automobil automobil = db.Automobile.Find(id);
            if (automobil == null)
            {
                return NotFound();
            }

            // 1. A sosit un fișier?
            if (fisier == null || fisier.Length == 0)
            {
                ModelState.AddModelError("fisier", "Alege un fișier.");
                return View(automobil);
            }
            // 2. Nu este prea mare? (2 MB)
            if (fisier.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("fisier", "Fișierul are mai mult de 2 MB.");
                return View(automobil);
            }
            // 3. Are o extensie permisă?
            string extensie = Path.GetExtension(fisier.FileName).ToLower();
            if (extensie != ".jpg" && extensie != ".jpeg" && extensie != ".png")
            {
                ModelState.AddModelError("fisier", "Sunt permise doar fișiere .jpg, .jpeg și .png.");
                return View(automobil);
            }

            // 4. Numele îl alege aplicația, nu browserul.
            string numeNou = Guid.NewGuid().ToString() + extensie;
            string folder = Path.Combine(mediu.WebRootPath, "incarcari");
            Directory.CreateDirectory(folder);
            string cale = Path.Combine(folder, numeNou);
            using (FileStream flux = new FileStream(cale, FileMode.Create))
            {
                fisier.CopyTo(flux);
            }

            // 5. În baza de date intră doar numele fișierului.
            automobil.Fotografie = numeNou;
            db.SaveChanges();
            TempData["Mesaj"] = "Fotografia a fost salvată.";
            return RedirectToAction("Detalii", new { id = id });
        }

        // Lecția 12. Automobilele care trec de filtru, cu LINQ.
        // Condițiile se adună; interogarea pleacă spre baza de date abia la ToList().
        private List<Automobil> Filtreaza(int? filialaId, string caroserie,
                                          bool doarDisponibile, string text)
        {
            IQueryable<Automobil> interogare = db.Automobile.Include(a => a.Filiala);

            if (filialaId != null)
            {
                interogare = interogare.Where(a => a.FilialaId == filialaId);
            }
            if (!string.IsNullOrEmpty(caroserie))
            {
                interogare = interogare.Where(a => a.Caroserie == caroserie);
            }
            if (doarDisponibile)
            {
                interogare = interogare.Where(a => a.EsteDisponibil);
            }
            if (!string.IsNullOrEmpty(text))
            {
                string cautat = text.Trim().ToLower();
                interogare = interogare.Where(
                    a => (a.Marca + " " + a.Modelul).ToLower().Contains(cautat));
            }

            return interogare.OrderBy(a => a.Marca).ToList();
        }

        // Listele de opțiuni pentru formular. Se pregătesc la fiecare afișare a lui,
        // inclusiv când formularul revine cu erori.
        private void PregatesteListele()
        {
            ViewBag.Combustibili = Optiuni.Combustibili;
            ViewBag.Caroserii = new SelectList(Optiuni.Caroserii);

            // Lecția 12: opțiunile vin din tabel. Se trimite Id-ul, se vede denumirea.
            List<Filiala> filiale = db.Filiale.OrderBy(f => f.Denumire).ToList();
            ViewBag.Filiale = new SelectList(filiale, "Id", "Denumire");
        }
    }
}
