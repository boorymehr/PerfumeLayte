using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetCateguryList
{
    public interface IListCategury
    {


        Task<List<CateguryDto>> Execute();




        Task<CateguryDto> Execute(int ID);
    }
}
