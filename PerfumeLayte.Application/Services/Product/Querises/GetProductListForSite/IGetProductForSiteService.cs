using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite
{
    public interface IGetProductForSiteService
    {
        Task<ResultProductForSiteDto> Execute(GetListProductForSiteSend Send);
    }

    public enum Ordering
    {

        popularity = 0,
        date=1,
    }

}
