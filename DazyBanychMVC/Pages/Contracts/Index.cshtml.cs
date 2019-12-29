using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Contracts
{
    public class IndexModel : PageModel
    {
        private readonly DeliveryCompanyAPIBackend.Models.CompanyContext _context;

        public IndexModel(DeliveryCompanyAPIBackend.Models.CompanyContext context)
        {
            _context = context;
        }

        public IList<Contract> Contract { get;set; }

        public async Task OnGetAsync()
        {
            Contract = await _context.Contracts
                .Include(c => c.worker).ToListAsync();
        }
    }
}
