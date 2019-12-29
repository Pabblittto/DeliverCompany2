using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly DeliveryCompanyAPIBackend.Models.CompanyContext _context;

        public EditModel(DeliveryCompanyAPIBackend.Models.CompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.Receiver)
                .Include(o => o.Sender)
                .Include(o => o.department)
                .Include(o => o.pack).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }

            var SelectListPeople = new List<SelectListItem>();
            foreach (Person person in _context.People)
            {
                SelectListPeople.Add(new SelectListItem($"{person.Surname} {person.Name}", person.Id.ToString()));
            }
            ViewData["ReciverId"] = SelectListPeople;
            ViewData["SenderId"] = SelectListPeople;
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
           ViewData["PackId"] = new SelectList(_context.Packs, "Id", "Id");

            var PackageStates = new List<SelectListItem>(){
                new SelectListItem("On the Way","On the Way"),
                new SelectListItem("Delivered","Delivered"),
                new SelectListItem("Ready to send","Ready to send"),
                new SelectListItem("In Warehouse","In Warehouse")
            };

            ViewData["PackageStates"] = PackageStates;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Order.ReciverId == Order.SenderId)
            {

                if (Order.ReciverId == Order.SenderId)
                {
                    ModelState.AddModelError("", "Sender can not be the same as Receiver");
                }

                var SelectListPeople = new List<SelectListItem>();
                foreach (Person person in _context.People)
                {
                    SelectListPeople.Add(new SelectListItem($"{person.Surname} {person.Name}", person.Id.ToString()));
                }
                ViewData["ReciverId"] = SelectListPeople;
                ViewData["SenderId"] = SelectListPeople;
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
                ViewData["PackId"] = new SelectList(_context.Packs, "Id", "Id");

                var PackageStates = new List<SelectListItem>(){
                new SelectListItem("On the Way","On the Way"),
                new SelectListItem("Delivered","Delivered"),
                new SelectListItem("Ready to send","Ready to send"),
                new SelectListItem("In Warehouse","In Warehouse")
            };

                ViewData["PackageStates"] = PackageStates;
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
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

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
