using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetListProduct
{
    public class ReslutGetListProductDto
    {
        public List<GetListProductDto> GetListProduct { get; set; }


        public int RowCount { get; set; }
    }
}
