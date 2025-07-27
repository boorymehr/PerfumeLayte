using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;

namespace PerfumeLayte.Application.Services.Product.Querises.isProductByID
{
    public class isProductByIDServices
    {
        private readonly IDataBaseContext _context;
        public isProductByIDServices(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Execute(int ProductID)
        {
            bool res = await _context.Product.AnyAsync(p => p.ID == ProductID);
            return res;

        }
    }
}
