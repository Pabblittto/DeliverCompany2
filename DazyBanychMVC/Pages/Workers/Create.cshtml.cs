using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Workers
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
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
        ViewData["PositionId"] = new SelectList(_context.Positions, "Name", "Name");
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
                ViewData["PositionId"] = new SelectList(_context.Positions, "Name", "Name");
                return Page();
            }

            _context.Workers.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}