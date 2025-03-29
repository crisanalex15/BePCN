using System.Diagnostics;
using BackEndProduseCheltuieliNotite.Models;
using BackEndProduseCheltuieliNotite.Models.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProduseCheltuieliNotite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("api/produse/adauga")]
        [HttpPost]
        public async Task<IActionResult> AdaugaProdus(string nume, decimal pret, int qt)
        {
            var produs = new Product { Name = nume, Price = pret, Quantity= qt };
            _context.Products.Add(produs);
            await _context.SaveChangesAsync();

            return Json(new { succes = true, mesaj = $"Produsul {nume} a fost adăugat!" });
        }

        [Route("api/produse")]
        [HttpGet]
        public async Task<IActionResult> Produse()
        {
            var produse = await _context.Products.ToListAsync();
            return Json(produse);
        }

        [Route("api/cheltuieli/adauga")]
        [HttpPost]
        public async Task<IActionResult> AdaugaCheltuiala(string nume, decimal suma, DateTime data)
        {
            var cheltuiala = new Expense { Name = nume, Price = suma, Date = data };
            _context.Expenses.Add(cheltuiala);
            await _context.SaveChangesAsync();
            return Json(new { succes = true, mesaj = $"Cheltuiala {nume} a fost adăugată!" });
        }

        [Route("api/cheltuieli")]
        [HttpGet]
        public async Task<IActionResult> Cheltuieli()
        {
            var cheltuieli = await _context.Expenses.ToListAsync();
            return Json(cheltuieli);
        }

        [Route("api/notite/adauga")]
        [HttpPost]
        public async Task<IActionResult> AdaugaNotita(string continut)
        {
            var notita = new Note { Content = continut };
            _context.Notes.Add(notita);
            await _context.SaveChangesAsync();
            return Json(new { succes = true, mesaj = $"Notița a fost adăugată!" });
        }

        [Route("api/notite")]
        [HttpGet]
        public async Task<IActionResult> Notite()
        {
            var notite = await _context.Notes.ToListAsync();
            return Json(notite);
        }

        [Route("api/delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, string type)
        {
            switch (type.ToLower())
            {
                case "product":
                    var product = await _context.Products.FindAsync(id);
                    if (product == null)
                        return Json(new { succes = false, mesaj = "Produsul nu a fost găsit!" });
                    
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return Json(new { succes = true, mesaj = "Produsul a fost șters cu succes!" });

                case "expense":
                    var expense = await _context.Expenses.FindAsync(id);
                    if (expense == null)
                        return Json(new { succes = false, mesaj = "Cheltuiala nu a fost găsită!" });
                    
                    _context.Expenses.Remove(expense);
                    await _context.SaveChangesAsync();
                    return Json(new { succes = true, mesaj = "Cheltuiala a fost ștearsă cu succes!" });

                case "note":
                    var note = await _context.Notes.FindAsync(id);
                    if (note == null)
                        return Json(new { succes = false, mesaj = "Notița nu a fost găsită!" });
                    
                    _context.Notes.Remove(note);
                    await _context.SaveChangesAsync();
                    return Json(new { succes = true, mesaj = "Notița a fost ștearsă cu succes!" });

                default:
                    return Json(new { succes = false, mesaj = "Tip invalid!" });
            }
        }

        public IActionResult GetToApi()
        {
            return Redirect("/swagger");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
