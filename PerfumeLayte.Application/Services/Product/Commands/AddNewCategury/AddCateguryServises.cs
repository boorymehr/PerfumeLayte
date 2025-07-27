using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Querises.GetCateguryById;
using PerfumeLayte.Domain.Entity.Categurys;

namespace PerfumeLayte.Application.Services.Product.Commands.AddNewCategury
{
    public class AddCateguryServises : IAddCateguryServises
    {
        private readonly IDataBaseContext _context;
        private readonly GetCategutyById _GetCategutyById;
        public AddCateguryServises(IDataBaseContext context, GetCategutyById GetCategutyById)
        {
            _context = context;
            _GetCategutyById = GetCategutyById;
        }
        public async Task<bool> AddCategury(int ParentID, CateguryAddDto categuryDto)
        {
            try
            {
                Categury Categury = new Categury();
                Categury.Name = categuryDto.CateguryName;
                if (ParentID == 0)
                {

                    Categury.ParentCategoryId = null;
                }
                else
                {
                    var CateguryParent = await _GetCategutyById.GetCategury(ParentID);
                    if(CateguryParent != null)
                    {
                        Categury.ParentCategoryId = ParentID;
                    }
                    else
                    {
                        Categury.ParentCategoryId = null;
                    }
                }
                await _context.Categuries.AddAsync(Categury);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
