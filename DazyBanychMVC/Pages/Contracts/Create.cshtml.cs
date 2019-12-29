using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Contracts
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
            var SelectList = new List<SelectListItem>();
            foreach (Worker worker in _context.Workers)
            {
                SelectList.Add(new SelectListItem($"{worker.Surname} {worker.Name}",worker.Id.ToString()));
            }
            ViewData["WorkerId"] = SelectList;
            //ViewData["WorkerId"] = new SelectList(_context.Workers, "Id", "Name","Surname");
            
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contracts.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}