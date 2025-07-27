using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.Product.Querises.GetListProduct;
using PerfumeLayte.Comman;

namespace PerfumeLayte.Application.Services.Product.Querises.GetCateguryList
{
    public class ListCategury : IListCategury
    {
        private readonly IDataBaseContext _context;
        public ListCategury(IDataBaseContext context)
        {
            _context = context;
        }

     

        public async Task<List<CateguryDto>> Execute()
        {
            List<CateguryDto> ListPro = await _context.Categuries.Select(c => new CateguryDto()
            {
                CateguryDtoID = c.ID,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
                SubCategurys =  _context.Categuries.Where(c => c.ParentCategoryId != null).Select(c => new CateguryDto()
                {
                    CateguryDtoID = c.ID,
                    Name = c.Name,
                    ParentCategoryId = c.ParentCategoryId
                }).ToList()
            }).ToListAsync();
            return ListPro;
        }

        public async Task<CateguryDto> Execute(int ID)
        {
            return await _context.Categuries.Where(c=> c.ID == ID).Select(c => new CateguryDto()
            {
                Name = c.Name,
                CateguryDtoID = c.ID,
                ParentCategoryId = c.ParentCategoryId
            }).SingleOrDefaultAsync();
        }
    }
}
