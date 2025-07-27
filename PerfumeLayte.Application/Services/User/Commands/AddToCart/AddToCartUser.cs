using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;
using PerfumeLayte.Domain.Entity.Product;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.User.Commands.AddToCart
{
    public class AddToCartUser : IAddToCartUser
    {
        private readonly IUserByMobileDetile _IUserByMobileDetile;
        private  IDataBaseContext _Context;
        private readonly IFacadProduct _IFacadProduct;
        public AddToCartUser(IDataBaseContext Context, IFacadProduct IFacadProduct, IUserByMobileDetile IUserByMobileDetile)
        {
            _Context = Context;
            _IFacadProduct = IFacadProduct;
            _IUserByMobileDetile = IUserByMobileDetile;
        }

        public async Task<bool> AddAdress(string Address, string Mobile)
        {
            var User = await _Context.User.Where(u => u.Mobile == Mobile).SingleOrDefaultAsync();
            if (User != null)
            {
                User.Address = Address;
                await _Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Execut(int UserID, int ProductID, int Count = 0)
        {
            var User = await _Context.User.FindAsync(UserID);
            var Product = await _IFacadProduct.IGetProductByIDServices.Execute(ProductID);

            if (User != null && Product != null)
            {
                var CartUser = await _Context.Cart
                    .Where(c => c.UserID == UserID && !c.isFinaly && !c.isDelete)
                    .SingleOrDefaultAsync();

                if (CartUser == null)
                {
                    Cart newCart = new Cart()
                    {
                        UserID = UserID,
                        isDelete = false,
                        isFinaly = false,
                        Price = ""
                    };

                    decimal PriceDatabaseS = await this.UpdateDatabasePrice(newCart.ID);
                    // تبدیل به رشته و ذخیره در CartUser.Price
                    newCart.Price = PriceDatabaseS.ToString("0.##"); // نمایش بدون اعشار اضافی
                    await _Context.Cart.AddAsync(newCart);
                    await _Context.SaveChangesAsync();

                    CartUser = newCart;
                }

                var CartItem = await _Context.CartItem
                    .Where(i => i.CartId == CartUser.ID && i.ProductId == ProductID && !i.isDelete)
                    .SingleOrDefaultAsync();

                if (CartItem == null)
                {
                    CartItem newItem = new CartItem()
                    {
                        ProductId = ProductID,
                        Count = Count,
                        CartId = CartUser.ID,
                        Price = (Count > 0) ? Convert.ToInt32(Product.Price) * Count : Convert.ToInt32(Product.Price)
                    }
                ;

                    decimal PriceDatabase = await this.UpdateDatabasePrice(CartUser.ID);
                    // تبدیل به رشته و ذخیره در CartUser.Price
                    CartUser.Price = PriceDatabase.ToString("0.##"); // نمایش بدون اعشار اضافی
                    await _Context.CartItem.AddAsync(newItem);
                    await _Context.SaveChangesAsync();
                }
                else
                {
                    if(Count > 0)
                    {
                        CartItem.Count = Count;
                    }
                    else
                    {
                        CartItem.Count++;
                        
                    }
                    decimal PriceDatabase = await this.UpdateDatabasePrice(CartUser.ID);
                    // تبدیل به رشته و ذخیره در CartUser.Price
                    CartUser.Price = PriceDatabase.ToString("0.##"); // نمایش بدون اعشار اضافی
                    await _Context.SaveChangesAsync();
                }
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCartItem(string Mobile, int ProductID)
        {
            var User = await _Context.User.Where(u => u.Mobile == Mobile).SingleOrDefaultAsync();
            var Product = await _Context.Product.Where(p => p.ID == ProductID).AnyAsync();
            if (User != null && Product)
            {
                var CartUser = await _Context.Cart
                    .Where(c => c.UserID == User.ID && !c.isFinaly && !c.isDelete)
                    .AsQueryable().SingleOrDefaultAsync();




               if(CartUser != null)
                {
                    var CartItem = await _Context.CartItem
                  .Where(i => i.CartId == CartUser.ID && i.ProductId == ProductID && !i.isDelete)
                  .SingleOrDefaultAsync();

                    if (CartItem != null)
                    {

                        CartItem.isDelete = true;

                        decimal PriceDatabase = await this.UpdateDatabasePrice(CartUser.ID);
                        // تبدیل به رشته و ذخیره در CartUser.Price
                        CartUser.Price = PriceDatabase.ToString("0.##"); // نمایش بدون اعشار اضافی
                        await _Context.SaveChangesAsync();
                        return true;
                    }
                }

            }
            return false;

        }

        public async Task<decimal> UpdateDatabasePrice(int id)
        {
            var cartItems = await _Context.CartItem
.Where(i => i.CartId == id && !i.isDelete).AsQueryable()
.Include(i => i.Product) // برای دسترسی به Product.Price
.ToListAsync();


            decimal totalPrice = cartItems.Sum(i => i.Count * Convert.ToInt32(i.Product.Price));

            return totalPrice;

        }

        public async Task<bool> PluseCart(int UserID, int ProductID)
        {
            var user = await _Context.User.FindAsync(UserID);
            var product = await _IFacadProduct.IGetProductByIDServices.Execute(ProductID);

            var cartUser = await _Context.Cart
                .Where(c => c.UserID == UserID && !c.isFinaly && !c.isDelete)
                .SingleOrDefaultAsync();

            if (cartUser == null && user == null && product == null)
                return false;

            var cartItem = await _Context.CartItem
                .Where(i => i.CartId == cartUser.ID && i.ProductId == ProductID && !i.isDelete)
                .SingleOrDefaultAsync();

            if (cartItem == null)
                return false;

            if (cartItem.Count < 10)
            {
                cartItem.Count++;
            }

            // به‌روزرسانی قیمت
            decimal priceDatabase = await this.UpdateDatabasePrice(cartUser.ID);
            cartUser.Price = priceDatabase.ToString("0.##");

            // ذخیره‌سازی نهایی
            await _Context.SaveChangesAsync();

            return true;


        }
       

        public async Task<bool> RemCart(int UserID, int ProdyctID)
        {
            var user = await _Context.User.FindAsync(UserID);
            var product = await _IFacadProduct.IGetProductByIDServices.Execute(ProdyctID);

            var cartUser = await _Context.Cart
                .Where(c => c.UserID == UserID && !c.isFinaly && !c.isDelete)
                .SingleOrDefaultAsync();

            if (cartUser == null)
                return false;

            var cartItem = await _Context.CartItem
                .Where(i => i.CartId == cartUser.ID && i.ProductId == ProdyctID && !i.isDelete)
                .SingleOrDefaultAsync();

            if (cartItem == null)
                return false;

            if (cartItem.Count > 1)
            {
                cartItem.Count--;
            }
            else
            {
                // اگر فقط یک عدد بود، حذف منطقی انجام بده
                cartItem.isDelete = true;
            }

            // به‌روزرسانی قیمت
            decimal priceDatabase = await this.UpdateDatabasePrice(cartUser.ID);
            cartUser.Price = priceDatabase.ToString("0.##");

            // ذخیره‌سازی نهایی
            await _Context.SaveChangesAsync();

            return true;


        }
    }
}
