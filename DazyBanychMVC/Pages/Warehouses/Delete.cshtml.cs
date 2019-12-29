using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Warehouses
{
    public class DeleteModel : PageModel
    {
        private readonly DeliveryCompanyAPIBackend.Models.CompanyContext _context;

        public DeleteModel(DeliveryCompanyAPIBackend.Models.CompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Warehous Warehous { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehous = await _context.Warehouses
                .Include(w => w.department).FirstOrDefaultAsync(m => m.Id == id);

            if (Warehous == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Warehous = await _context.Warehouses.FindAsync(id);

            if (Warehous != null)
            {
                _context.Warehouses.Remove(Warehous);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
