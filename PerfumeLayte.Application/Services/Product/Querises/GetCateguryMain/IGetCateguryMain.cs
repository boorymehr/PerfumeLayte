using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetCateguryMain
{
    public interface IGetCateguryMain
    {
        Task<List<int>> GetCateguryMainLayout();
    }
}
