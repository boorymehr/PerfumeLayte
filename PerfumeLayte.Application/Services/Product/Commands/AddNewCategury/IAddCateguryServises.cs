using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Commands.AddNewCategury
{
    public interface IAddCateguryServises
    {
        Task<bool> AddCategury(int ParentID,CateguryAddDto categuryDto);
    }
}
