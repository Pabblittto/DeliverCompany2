using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeliveryCompanyAPIBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DazyBanychMVC.Pages.Orders
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
            var SelectListPeople = new List<SelectListItem>();
            foreach (Person person in _context.People)
            {
                SelectListPeople.Add(new SelectListItem($"{person.Surname} {person.Name}", person.Id.ToString()));
            }
            ViewData["ReciverId"] = SelectListPeople;
            ViewData["SenderId"] = SelectListPeople;


            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
           // var Packages= 
            var PackageList = new List<SelectListItem>();
            foreach (Pack pack in _context.Packs.Include(ob=>ob.order).ToList())
            {
                if (pack.order == null)
                    PackageList.Add(new SelectListItem("Id:"+pack.Id.ToString()+" Type:"+ pack.PackTypeId , pack.Id.ToString()));
            }

            ViewData["PackId"] = PackageList;

            var PackageStates = new List<SelectListItem>(){
                new SelectListItem("On the Way","On the Way"),
                new SelectListItem("Delivered","Delivered"),
                new SelectListItem("Ready to send","Ready to send"),
                new SelectListItem("In Warehouse","In Warehouse")
                };

            ViewData["PackageStates"] = PackageStates;
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Order.ReciverId==Order.SenderId)
            {
                if(Order.ReciverId == Order.SenderId)
                {
                    ModelState.AddModelError("","Sender can not be the same as Receiver");
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

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}