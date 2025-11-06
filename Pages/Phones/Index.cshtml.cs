using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Data;
using PhoneCatalog.Models;

namespace PhoneCatalog.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly PhoneDbContext _db;
        public IndexModel(PhoneDbContext db) => _db = db;

        public List<Phone> Items { get; private set; } = new();

        public async Task OnGet()
        {
            Items = await _db.Phones.AsNoTracking()
                .OrderBy(p => p.Brand).ThenBy(p => p.Model)
                .ToListAsync();
        }
    }
}
