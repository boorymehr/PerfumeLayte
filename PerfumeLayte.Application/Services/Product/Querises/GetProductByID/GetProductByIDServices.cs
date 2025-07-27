
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;

using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.Product;

namespace PerfumeLayte.Application.Services.Product.Querises.GetProductByID
{
    public class GetProductByIDServices : IGetProductByIDServices
    {
        private readonly IDataBaseContext _context;
        public GetProductByIDServices(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyGetProduct(int ProductID)
        {
            return await _context.Product.Where(p => p.ID == ProductID).AnyAsync();
        }

        public async Task<GetProductByID> Execute(int ProductID)
        {
            var Product = await _context.Product.Where(p => p.ID == ProductID).Include(i => i.Imgs)
                .Include(c => c.Categury).Include(c => c.Comments)
                .Select(p => new GetProductByID()
                {
                    ID = p.ID,
                    Price = p.Price,
                    Name = p.Name,
                    text = p.Voluome,
                    Brand = p.Brand,
                    isVisite = p.isVisite,
                    CommentsDto = p.Comments.Select(c => new CommentsDto() { MainText = c.MainText,Title = c.Title, UserName = c.User.FullName ?? c.User.Mobile ?? c.User.Mobile }).ToList(),
                    isTahkfif = p.isTahkfif,
                    PriceNew = p.PriceNew,
                    feature = p.Feacher,
                    ScrMain = p.ScrMain,
                    src = p.Imgs.Select(i => i.src).ToList(),
                    categury = p.Categury.Name

                }).SingleOrDefaultAsync();
            return Product;
        }
    }
}
