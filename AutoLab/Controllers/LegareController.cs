using Microsoft.AspNetCore.Mvc;
using AutoLab.Models;
using AutoLab.Data;

namespace AutoLab.Controllers
{
    // Pagina „Laborator de legare”: experimente mici cu legarea modelului.
    public class LegareController : Controller
    {
        private AutoDbContext db;

        public LegareController(AutoDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Pasul 1. GET /Legare/Simple?an=2020&pretMaxim=200000&doarDisponibile=true
        public IActionResult Simple(int? an, decimal? pretMaxim, bool doarDisponibile)
        {
            List<Automobil> gasite = new List<Automobil>();
            foreach (Automobil automobil in db.Automobile)
            {
                bool potrivit = true;
                if (an != null && automobil.AnFabricatie != an)
                {
                    potrivit = false;
                }
                if (pretMaxim != null && automobil.Pret > pretMaxim)
                {
                    potrivit = false;
                }
                if (doarDisponibile && !automobil.EsteDisponibil)
                {
                    potrivit = false;
                }
                if (potrivit)
                {
                    gasite.Add(automobil);
                }
            }
            ViewBag.An = an;
            ViewBag.PretMaxim = pretMaxim;
            ViewBag.DoarDisponibile = doarDisponibile;
            return View(gasite);
        }

        // Experiment: int fără semnul întrebării. GET /Legare/FaraNull?an=abc
        public IActionResult FaraNull(int an)
        {
            ViewBag.An = an;
            return View();
        }

        // Pasul 5. Aceeași valoare, trimisă prin mai multe surse.
        public IActionResult Prioritate(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        // Pasul 5. Fiecare parametru își spune sursa.
        [HttpPost]
        public IActionResult Surse([FromForm(Name = "id")] int dinFormular,
                                   [FromRoute(Name = "id")] int dinRuta,
                                   [FromQuery(Name = "id")] int dinAdresa,
                                   [FromHeader(Name = "User-Agent")] string browser)
        {
            ViewBag.DinFormular = dinFormular;
            ViewBag.DinRuta = dinRuta;
            ViewBag.DinAdresa = dinAdresa;
            ViewBag.Browser = browser;
            return View();
        }

        // Pasul 6. Parametrul filiala vine din cookie, prin furnizorul propriu.
        public IActionResult Filiala(string filiala)
        {
            ViewBag.Filiala = filiala;
            return View();
        }

        [HttpPost]
        public IActionResult AlegeFiliala(string oras)
        {
            Response.Cookies.Append("filiala", oras);
            return RedirectToAction("Filiala");
        }
    }
}
