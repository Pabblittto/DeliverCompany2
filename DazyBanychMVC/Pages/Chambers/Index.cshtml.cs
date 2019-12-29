using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeliveryCompanyAPIBackend.Models;

namespace DazyBanychMVC.Pages.Chambers
{
    public class IndexModel : PageModel
    {
        private readonly DeliveryCompanyAPIBackend.Models.CompanyContext _context;

        public IndexModel(DeliveryCompanyAPIBackend.Models.CompanyContext context)
        {
            _context = context;
        }

        public IList<Chamber> Chamber { get;set; }

        public async Task OnGetAsync()
        {
            Chamber = await _context.Chambers
                .Include(c => c.chamberType)
                .Include(c => c.parcelLocker).ToListAsync();
        }
    }
}
