using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Packs
{
    public class CreateModel : PageModel
    {
        private readonly DeliveryCompanyAPIBackend.Models.CompanyContext _context;

        public CreateModel(DeliveryCompanyAPIBackend.Models.CompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PackTypeId"] = new SelectList(_context.PackTypes, "Name", "Name");
            return Page();
        }

        [BindProperty]
        public Pack Pack { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Packs.Add(Pack);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}