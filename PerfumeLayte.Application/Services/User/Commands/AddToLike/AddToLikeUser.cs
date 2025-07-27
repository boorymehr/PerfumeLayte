using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.FacadProduct;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.User.Commands.AddToLike
{
    public class AddToLikeUser : IAddToLikeUser
    {
        private readonly IFacadProduct _facadProduct;
        private IDataBaseContext _context;
        public AddToLikeUser(IDataBaseContext context, IFacadProduct facadProduct)
        {
            _context = context;
            _facadProduct = facadProduct;
        }

        public async Task<bool> AddToLike(int UserID, int ProductID)
        {
            var Product = await _context.Product.FindAsync(ProductID);
            var User = await _context.User.FindAsync(UserID);

            if (Product != null || User != null)
            {
               
                    LikeProduct likeProduct = new LikeProduct()
                    {
                        UserID = UserID,
                        Product = Product,
                        User = User,
                        ProductID = Product.ID

                    };
                    await _context.LikeProduct.AddAsync(likeProduct);
                    await _context.SaveChangesAsync();


                    return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<LikeDto>> GetListLikeUser(int UserID)
        {
            return await _context.LikeProduct.Include(p => p.Product).Where(l => l.UserID == UserID).AsQueryable().Select(l => new LikeDto()
            {
                UserID = UserID,
                Price = l.Product.Price,
                ProductID = l.Product.ID,
                ScrMain = l.Product.ScrMain,
                Name = l.Product.Name
            }).ToListAsync();
        }

        public Task<bool> RemToLike(int UserID, int ProductID)
        {
            throw new NotImplementedException();
        }
    }
}
