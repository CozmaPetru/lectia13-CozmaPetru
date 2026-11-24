using Microsoft.AspNetCore.Mvc;

namespace AutoLab.Controllers
{
    // Pagina „Laborator AJAX”: acțiuni mici, făcute ca să vezi
    // cum arată în browser fiecare tip de răspuns.
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET /Demo/Salut → un text simplu, cu ora serverului
        public IActionResult Salut()
        {
            return Content("Salut de la server! Ora serverului: " + DateTime.Now.ToString("HH:mm:ss"));
        }

        // GET /Demo/Lent → același răspuns, dar după 2 secunde
        public IActionResult Lent()
        {
            Thread.Sleep(2000);
            return Content("Răspuns sosit după 2 secunde, la " + DateTime.Now.ToString("HH:mm:ss"));
        }

        // GET /Demo/Eroare → excepție pe server, deci codul 500
        public IActionResult Eroare()
        {
            throw new Exception("Eroare provocată intenționat pentru lecția 10.");
        }
    }
}
