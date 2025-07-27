using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.Product;
using System;
using System.Linq;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite
{
    public class GetProductForSiteService : IGetProductForSiteService
    {

        private IDataBaseContext _context;
        public GetProductForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultProductForSiteDto> Execute(GetListProductForSiteSend Send)
        {
            int totalRow = 0;
            IQueryable<PerfumeLayte.Domain.Entity.Product.Product> productQuery = _context.Product.Include(p => p.Categury).AsQueryable();

            if(Send.CatID != null && Send.CatID != 0)
            {
                productQuery = productQuery.Where(p => p.CateguryID == Send.CatID || p.Categury.ParentCategoryId == Send.CatID).AsQueryable();
            }
            if (Send.Brand != null)
            {
                productQuery = productQuery.Where(p => p.Brand.Contains(Send.Brand)).AsQueryable();
            }
            
        
            if (!string.IsNullOrWhiteSpace(Send.searchkey))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(Send.searchkey) || p.Brand.Contains(Send.searchkey)).AsQueryable();
            }

            switch (Send.Ordering)
            {
                case Ordering.popularity:
                    productQuery = productQuery.OrderByDescending(p => p.ID).AsQueryable();
                    break;
                case Ordering.date:
                    productQuery = productQuery.OrderBy(p => p.CreateData).AsQueryable();
                    break;
                default:
                    break;
            }

            var product=productQuery.ToPaged(Send.page,  Send.pageSize, out totalRow);

            Random rd = new Random();
            return new ResultProductForSiteDto
            {
                    TotalRow = totalRow,
                    Products = product.Select(p => new ProductForSiteDto
                    {
                        Id = p.ID,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ScrMain.ToString(),
                        Price= Convert.ToInt32(p.Price),
                    }).ToList(),
            };
        }
    }

}
