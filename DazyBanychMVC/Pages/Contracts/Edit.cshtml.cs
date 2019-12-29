using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Contracts
{
    public class EditModel : PageModel
    {
        private readonly DeliveryCompanyAPIBackend.Models.CompanyContext _context;

        public EditModel(DeliveryCompanyAPIBackend.Models.CompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contracts
                .Include(c => c.worker).FirstOrDefaultAsync(m => m.Id == id);

            if (Contract == null)
            {
                return NotFound();
            }
            var SelectList = new List<SelectListItem>();
            foreach (Worker worker in _context.Workers)
            {
                SelectList.Add(new SelectListItem($"{worker.Surname} {worker.Name}", worker.Id.ToString()));
            }
            ViewData["WorkerId"] = SelectList;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var SelectList = new List<SelectListItem>();
                foreach (Worker worker in _context.Workers)
                {
                    SelectList.Add(new SelectListItem($"{worker.Surname} {worker.Name}", worker.Id.ToString()));
                }
                ViewData["WorkerId"] = SelectList;
                return Page();
            }

            _context.Attach(Contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(Contract.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
