using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductByID
{
    public interface IGetProductByIDServices
    {
        Task<GetProductByID> Execute(int ProductID);

        Task<bool> AnyGetProduct(int ProductID);
    }
}
