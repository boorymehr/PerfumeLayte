using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;

namespace PerfumeLayte.Application.Services.Product.Querises.GetCateguryMain
{
    public class GetCateguryMain : IGetCateguryMain
    {
        private readonly IDataBaseContext _context;
        public GetCateguryMain(IDataBaseContext context)
        {
            _context = context;
        }

         public async Task<List<int>> GetCateguryMainLayout()
        {
            return await _context.Categuries.Where(c => c.ParentCategoryId == null).Select(c => c.ID).ToListAsync();
        }
    }
}
