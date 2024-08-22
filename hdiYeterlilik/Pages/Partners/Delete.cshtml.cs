using hdiYeterlilik.Data;
using hdiYeterlilik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace hdiYeterlilik.Pages.Partners
{
    public class DeletePartnerModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeletePartnerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Partner Partner { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Partner = await _context.Partners.FindAsync(id);

            if (Partner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var partner = await _context.Partners.FindAsync(id);

            if (partner != null)
            {
                _context.Partners.Remove(partner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Partners");
        }
    }
}
