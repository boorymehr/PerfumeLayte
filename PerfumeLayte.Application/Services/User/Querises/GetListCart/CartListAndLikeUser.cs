using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.User.Querises.GetCartActive;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;

namespace PerfumeLayte.Application.Services.User.Querises.GetListCart
{
    public class CartListAndLikeUser : ICartListAndLikeUser
    {
        private IDataBaseContext _Context;
        private IUserByMobileDetile _IUserByMobileDetile;
        public CartListAndLikeUser(IDataBaseContext Context, IUserByMobileDetile IUserByMobileDetile)
        {
            _Context = Context;
            _IUserByMobileDetile = IUserByMobileDetile;
        }
        public async Task<List<UserListCartDto>> GetListCartUser(string Mobile)
        {
            int userID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            //return await _Context.Cart.Include(u => u.CartItem).ThenInclude(C => C.Product).ThenInclude(p => p.Imgs).Where(u => u.UserID == userID && !u.isFinaly).Select(u => new CartUserDto()
            //{
            //    price = u.Price,
            //    CartItemDto = u.CartItem.Where(i => !i.isDelete).Select(i => new CartItemDto(){Count = i.Count,Img = i.Product.ScrMain,name = i.Product.Name,price = i.Product.Price}).ToList()
            //}).SingleOrDefaultAsync();
            return await _Context.Cart.Where(u => u.UserID == userID && u.isFinaly && !u.isDelete).AsQueryable().Select(c => new UserListCartDto()
            {
                ID = c.ID,
                price = c.Price,
                isFinal = c.isFinaly
            }).ToListAsync();

        }

        public Task<List<LikeUserProductDto>> GetListLikeUser()
        {
            throw new NotImplementedException();
        }
    }
}
