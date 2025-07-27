using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Commands.EditProductByID
{
    public interface IEditProduct
    {
        Task<bool> Execute(EditProductDto Pro,string MainSrc,List<string> Scr);
    }
}
