using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.FacadProduct;
using PerfumeLayte.Application.Services.User.Commands.AddToCart;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;

namespace PerfumeLayte.Application.Services.User.Querises.GetCartActive
{
    public class GetCartUserActive : IGetCartUserActive
    {
        private IAddToCartUser _IAddToCartUser;
        private readonly IDataBaseContext _Context;
        private readonly IUserByMobileDetile _IUserByMobileDetile;
        public GetCartUserActive(IDataBaseContext Context,
            IUserByMobileDetile IUserByMobileDetile, IAddToCartUser IAddToCartUser)
        {
            _Context = Context;
            _IUserByMobileDetile = IUserByMobileDetile;
            _IAddToCartUser = IAddToCartUser;
        }
        public async Task<CartUserDto> GetCartActive(string Mobile)
        {
            int userID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            //return await _Context.Cart.Include(u => u.CartItem).ThenInclude(C => C.Product).ThenInclude(p => p.Imgs).Where(u => u.UserID == userID && !u.isFinaly).Select(u => new CartUserDto()
            //{
            //    price = u.Price,
            //    CartItemDto = u.CartItem.Where(i => !i.isDelete).Select(i => new CartItemDto(){Count = i.Count,Img = i.Product.ScrMain,name = i.Product.Name,price = i.Product.Price}).ToList()
            //}).SingleOrDefaultAsync();
            Domain.Entity.User.Cart? cartUser = await _Context.Cart.Where(u => u.UserID == userID && !u.isFinaly && !u.isDelete).SingleOrDefaultAsync();
            if (cartUser != null)
            {
                var cartitemuser = await _Context.CartItem.Include(c => c.Product).ThenInclude(p => p.Imgs).Where(u => u.CartId == cartUser.ID && !u.isDelete).ToListAsync();

                List<CartItemDto> CartUserDtoItem = new List<CartItemDto>();
                foreach (var Items in cartitemuser)
                {
                    CartUserDtoItem.Add(new CartItemDto()
                    {
                        Count = Items.Count,
                        ID = Items.Product.ID,
                        Img = Items.Product.ScrMain,
                        name = Items.Product.Name,
                        price = Items.Product.Price
                    });
                }



                decimal PriceDatabase = await _IAddToCartUser.UpdateDatabasePrice(cartUser.ID);
                // تبدیل به رشته و ذخیره در CartUser.Price
                cartUser.Price = PriceDatabase.ToString("0.##"); // نمایش بدون اعشار اضافی
                await _Context.SaveChangesAsync();
                CartUserDto CartUserDto = new CartUserDto()
                {
                    price = cartUser.Price,
                    CartItemDto = CartUserDtoItem
                };
                return CartUserDto;
            }
            else
            {
                return new CartUserDto();
            }
            
        }

     
    }
}
