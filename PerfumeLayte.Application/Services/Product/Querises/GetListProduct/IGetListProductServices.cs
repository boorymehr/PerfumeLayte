using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetListProduct
{
    public interface IGetListProductServices
    {
        Task<List<GetListProductDto>> Execute(int Take, string Cat = "");

        Task<ReslutGetListProductDto> Execute(RequestGetListProductDto RequestGetListProductDto);
    }
}
