using System.Diagnostics;
using BackEndProduseCheltuieliNotite.Models;
using BackEndProduseCheltuieliNotite.Models.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProduseCheltuieliNotite.Controllers
{
    public class HomeController : Controller
    {

        // BAZA DE DATE + ILOGGER
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // PRODUSE

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

        // CHELTUIELI

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

        public IActionResult viewProducts()
        {
            var allProducts = _context.Products.ToList();
            return View(allProducts);
        }

        //create

        // edit
        public IActionResult viewProductsCreateEdit(int? id)
        {
            var idV = _context.Products.FirstOrDefault(p => p.Id == id);
            if (idV == null)
            {
                return View("viewProductsCreateEdit");
            }
            var product = _context.Products.Find(id);
            return View(product);
        }

        public IActionResult Search(string search, string type)
        {
               
            if (type == "product")
            {
                if (search == null)
                {
                    return RedirectToAction("viewProducts");
                }
                var products = _context.Products.Where(p => p.Name.Contains(search)).ToList();
                return View("viewProducts", products);
            }
            if(type == "expense")
            {
                if (search == null)
                {
                    return RedirectToAction("viewExpenses");
                }
                var expenses = _context.Expenses.Where(e => e.Name.Contains(search)).ToList();
                return View("viewExpenses", expenses);
            }
            return View("Index");

        }

        public IActionResult viewProductsCreateEditForm(Product product)
        {
            if (product.Id == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                _context.Products.Update(product);
            }
            _context.SaveChanges();
            return RedirectToAction("viewProducts");
        }

        public IActionResult viewExpensesCreateEdit(int? id)
        {
            var idFind = _context.Expenses.Find(id);
            if (idFind == null)
            {
                return View("viewExpensesCreateEdit");
            }

            var expense = _context.Expenses.Find(id);
            return View(expense);
        }

        public IActionResult viewExpensesCreateEditForm(Expense expense)
        {
            if (expense.Id == 0)
            {
                _context.Expenses.Add(expense);
            }
            else
            {
                _context.Expenses.Update(expense);
            }
            _context.SaveChanges();
            return RedirectToAction("viewExpenses");
        }


        public IActionResult DeleteFunc(int id, string type)
        {
            // select by type
            if (type == "product")
            {
                var product = _context.Products.Find(id);
                _context.Products.Remove(product);

                _context.SaveChanges();
                return RedirectToAction("viewProducts");
            }
            else if (type == "expense")
            {
                var expense = _context.Expenses.Find(id);
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
                return RedirectToAction("viewExpenses");
            }
            else if (type == "note")
            {
                var note = _context.Notes.Find(id);
                _context.Notes.Remove(note);
                _context.SaveChanges();

                return RedirectToAction("viewNotes");
            }
            return RedirectToAction("Index");
        }

        public IActionResult viewExpenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var expenses = _context.Expenses.OrderBy(e => e.Id).ToList();
            var totalPrice = allExpenses.Sum(e => e.Price);
            ViewBag.TotalPrice = totalPrice;
            return View(allExpenses);
        }

        public IActionResult viewNotes()
        {
            var allNotes = _context.Notes.ToList();
            return View(allNotes);
        }

        public IActionResult viewNotesCreateEdit(int? id)
        {
            if (id == null)
            {
                return View("viewNotesCreateEdit");
            }
            var note = _context.Notes.Find(id);
            return View(note);
        }

        public IActionResult viewNotesCreateEditForm(Note note)
        {
            if (note.Id == 0)
            {
                _context.Notes.Add(note);
            }
            else
            {
                _context.Notes.Update(note);
            }
            _context.SaveChanges();
            return RedirectToAction("viewNotes");
        }


        // site things
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
