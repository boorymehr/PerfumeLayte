using System.Collections.Generic;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite
{
    public class ResultProductForSiteDto
    {

        public List<ProductForSiteDto> Products { get; set; }
        public int? TotalRow { get; set; }
    }

}
