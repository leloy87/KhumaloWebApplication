using KhumaloWebApplication.Data;
using KhumaloWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KhumaloWebApplication.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
         
        }

        // Search action
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View("Search", new List<Products>());
            }

            var results = await _context.Product
                .Where(p => p.Name.Contains(query) || p.Description.Contains(query) || p.Category.Contains(query))
                .ToListAsync();

            return View("Search", results);
        }
    }
}
