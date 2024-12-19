using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalKsiazkowy.Models;

namespace PortalKsiazkowy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ManageBooks
        public async Task<IActionResult> ManageBooks()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        // GET: Admin/CreateBook
        public IActionResult CreateBook()
        {
            return View();
        }

        // POST: Admin/CreateBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook([Bind("Id,Title,Author,Genre,PublishedDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.AverageRating = 0;
                book.RatingsCount = 0;
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageBooks));
            }
            return View(book);
        }

        // POST: Admin/DeleteBook/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ManageBooks));
        }
    }
}
