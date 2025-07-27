using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryList;

namespace PerfumeLayte.Application.Services.Product.Querises.GetCateguryById
{
    public class GetCategutyById
    {
        private readonly IDataBaseContext _context;
        public GetCategutyById(IDataBaseContext context)
        {
            _context = context;
        }

        public Task<CateguryDto> GetCategury(int CateguryID)
        {
            return _context.Categuries.Where(c => c.ID == CateguryID).Select(c=> new CateguryDto()
            {
                CateguryDtoID = c.ID,
                Name = c.Name
            }).SingleOrDefaultAsync();
        }

    }
}
