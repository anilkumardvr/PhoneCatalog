using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PhoneCatalog.Pages
{
    public class IndexModel : PageModel
    {
        public string HeroTitle => "Find your next phone";
        public string HeroSubtitle => "20+ models · real photos · quick specs";
        public void OnGet() { }
    }
}
