
// File: Pages/Phones/Details.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Data;
using PhoneCatalog.Models;

namespace PhoneCatalog.Pages.Phones
{
    public class DetailsModel : PageModel
    {
        private readonly PhoneDbContext _db;
        public DetailsModel(PhoneDbContext db) => _db = db;

        public Phone? Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == id);
            if (Phone == null) return NotFound();
            return Page();
        }
    }
}
