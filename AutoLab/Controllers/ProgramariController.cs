using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoLab.Models;
using AutoLab.Data;

namespace AutoLab.Controllers
{
    // Lista programărilor la test-drive.
    public class ProgramariController : Controller
    {
        private AutoDbContext db;

        public ProgramariController(AutoDbContext db)
        {
            this.db = db;
        }

        // Lecția 12: programarea vine împreună cu automobilul ei, într-o interogare.
        public IActionResult Index()
        {
            List<Programare> programari = db.Programari
                .Include(p => p.Automobil)
                .OrderBy(p => p.Ziua)
                .ToList();
            return View(programari);
        }
    }
}
