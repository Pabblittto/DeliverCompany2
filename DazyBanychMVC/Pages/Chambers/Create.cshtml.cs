using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Chambers
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
        ViewData["ChamberTypeId"] = new SelectList(_context.ChamberTypes, "TypeName", "TypeName");
        ViewData["ParcelLockerId"] = new SelectList(_context.ParcelLockers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Chamber Chamber { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Chambers.Add(Chamber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}