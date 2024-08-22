using hdiYeterlilik.Data;
using hdiYeterlilik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace hdiYeterlilik.Pages.Partners
{
    public class EditPartnerModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditPartnerModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Partner).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(Partner.PartnerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Partners");
        }

        private bool PartnerExists(int id)
        {
            return _context.Partners.Any(e => e.PartnerID == id);
        }
    }
}
