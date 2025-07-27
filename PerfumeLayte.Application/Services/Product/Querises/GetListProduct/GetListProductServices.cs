
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;

using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.Product.Querises.GetListProduct
{
    public class GetListProductServices : IGetListProductServices
    {
        private readonly IDataBaseContext _context;
        public GetListProductServices(IDataBaseContext context)
        {
            _context = context;
        }


        public async Task<List<GetListProductDto>> Execute(int Take, string Cat ="")
        {
            var ProductsList = new List<GetListProductDto>();
            
            if(Cat == "همه")
            {
                var Products = _context.Product.AsQueryable();
                ProductsList = Products.Take(Take).Select(p => new GetListProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    PriceNew = p.PriceNew,
                    isTahkfif = p.isTahkfif,
                    ScrMain = p.ScrMain,
                    isVisite = p.isVisite,
                    ProductID = p.ID
                }).ToList();

            }
            
         
            if (Cat == "مردانه")
            {
                var Products = _context.Product.Include(p => p.Categury).AsQueryable();
                Products = Products.Where(p => p.Name.Contains(Cat) || p.Brand.Contains(Cat) || p.Categury.Name.Contains(Cat));
                ProductsList = Products.Take(Take).Select(p => new GetListProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    PriceNew = p.PriceNew,
                    isTahkfif = p.isTahkfif,
                    ScrMain = p.ScrMain,
                    isVisite = p.isVisite,
                    ProductID = p.ID
                }).ToList();
            }
            if (Cat == "زنانه")
            {
                var Products = _context.Product.Include(p => p.Categury).AsQueryable();
                Products = Products.Where(p => p.Name.Contains(Cat) || p.Brand.Contains(Cat) || p.Categury.Name.Contains(Cat));
                ProductsList = Products.Take(Take).Select(p => new GetListProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    PriceNew = p.PriceNew,
                    isTahkfif = p.isTahkfif,
                    ScrMain = p.ScrMain,
                    isVisite = p.isVisite,
                    ProductID = p.ID
                }).ToList();
            }

             
            if (Cat == "تازه ترین ها")
            {
                var Products = _context.Product.AsQueryable();
                Products = Products.OrderBy(p => p.CreateData);
                ProductsList = Products.Take(Take).Select(p => new GetListProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    PriceNew = p.PriceNew,
                    isTahkfif = p.isTahkfif,
                    ScrMain = p.ScrMain,
                    isVisite = p.isVisite,
                    ProductID = p.ID
                }).ToList();
            }
            return ProductsList;
        }

        public async Task<ReslutGetListProductDto> Execute(RequestGetListProductDto RequestGetListProductDto)
        {
            var Products = _context.Product.AsQueryable();
            if (RequestGetListProductDto.SearchKey != null)
            {
                Products = Products.Where(p => p.Name.Contains(RequestGetListProductDto.SearchKey) || p.Brand.Contains(RequestGetListProductDto.SearchKey));
            }
            int rowsCont;
            var ProductsList = Products.ToPaged(RequestGetListProductDto.Page, RequestGetListProductDto.PageSize,out rowsCont).Select(p => new GetListProductDto()
            {
                Name = p.Name,
                Price = p.Price,
                PriceNew = p.PriceNew,
                isTahkfif = p.isTahkfif,
                ScrMain = p.ScrMain,
                isVisite = p.isVisite,
                ProductID = p.ID
            }).ToList();

            var Resualt = new ReslutGetListProductDto()
            {
                GetListProduct = ProductsList,
                RowCount = rowsCont
            };
            return Resualt;
        }
    }
}
