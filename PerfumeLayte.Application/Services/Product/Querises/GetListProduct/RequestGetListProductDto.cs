using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetListProduct
{
    public class RequestGetListProductDto
    {
        public string SearchKey { get; set; }
        public int Page { get; set; }


        public int PageSize { get; set; }
    }
}
