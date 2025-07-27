using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite
{
    public class GetListProductForSiteSend
    {

        public int page { get; set; }

        public int pageSize { get; set; }
        public Ordering? Ordering { get; set; }


        public string? searchkey { get; set; }



        public int? CatID { get; set; }






        public int? InPrice { get; set; }
        public int? ToPrice { get; set; }
        public string? Brand { get; set; }

    }
}
