using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.Product.Querises.GetProductListForSite;
using PerfumeLayte.Application.Services.User.Commands.AddToCart;
using PerfumeLayte.Application.Services.User.Commands.AddToLike;
using PerfumeLayte.Application.Services.User.Querises.GetCartActive;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;
using PerfumeLayte.Domain.Entity.User;

namespace Perfume_Layte.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCartUserActive _Cart;
        private readonly IFacadProduct facadProduct;
        private IAddToCartUser _IAddToCartUser;
        private readonly IUserByMobileDetile _IUserByMobileDetile;
        private readonly IAddToLikeUser _IAddToLikeUser;
        public ProductController(IFacadProduct _facadProduct,
            IAddToCartUser IAddToCartUser, IUserByMobileDetile IUserByMobileDetile
            , IGetCartUserActive Cart, IAddToLikeUser IAddToLikeUser)
        {
            facadProduct = _facadProduct;
            _IAddToCartUser = IAddToCartUser;
            _IUserByMobileDetile = IUserByMobileDetile;
            _Cart = Cart;
            _IAddToLikeUser = IAddToLikeUser;
        }

        [HttpGet]
        public async Task<IActionResult> DetileProduct(int ProductID,string Message = "")
        {
            var DetileProduct = await facadProduct.IGetProductByIDServices.Execute(ProductID);
            ViewData["ListProductDetile"] = await facadProduct.IGetListProductServices.Execute(4, "همه");
            if (DetileProduct != null)
            {
                ViewData["Massege"] = Message;
                return View(DetileProduct);
            }
            return RedirectToAction("Index","Home");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddToCart(string Mobile,string ProductID,string CountProduct = "0")
        {
            int Count = Convert.ToInt32(CountProduct);
            int ProductIDConvert = Convert.ToInt32(ProductID);
            var UserID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            var DetileProduct = await facadProduct.IGetProductByIDServices.AnyGetProduct(ProductIDConvert);
            if (DetileProduct && UserID > 0)
            {
                bool AddToCartUser = await _IAddToCartUser.Execut(UserID, ProductIDConvert, Count);
                if(AddToCartUser)
                {
                    string Message = "به سبد خرید افزوده شد";
                    return RedirectToAction("DetileProduct", "Product", ProductIDConvert, Message);
                }
                else
                {
                    string Message = "مشکلی پیش امده دوباره امتحان کنید";
                    return RedirectToAction("DetileProduct", "Product", ProductIDConvert, Message);
                }
                    
            }
            else
            {
                return NotFound();
            }
        }




        [HttpGet]
        public async Task<IActionResult> Products(GetListProductForSiteSend Send,int pageid = 1,int CatID = 0)
        {
            Send.page = pageid;
            Send.CatID = CatID;
            Send.pageSize = 1;
            ViewData["ListCtegury"] = await facadProduct.IListCategury.Execute();
            var ListProducts = await facadProduct.IGetProductForSiteService.Execute(Send);
            return View(ListProducts);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PluseCart(int ProductID, string Mobile)
        {
            var UserID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            bool res = await _IAddToCartUser.PluseCart(UserID, ProductID);
            if (!res)
            {
                return Redirect("/");
            }
            else
            {
                return RedirectToAction("CartUserShowActive", "Product", new { mobile = Mobile });
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RemCart(int ProductID, string Mobile)
        {
            var UserID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            bool res = await _IAddToCartUser.RemCart(UserID, ProductID);
            if(!res)
            {
                return Redirect("/");
            }
            else
            {
                return RedirectToAction("CartUserShowActive", "Product", new { mobile = Mobile });
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListLike(string Mobile)
        {
            var UserID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            if (UserID > 0)
            {
                List<LikeDto> ListUserLike = await _IAddToLikeUser.GetListLikeUser(UserID);
                return View(ListUserLike);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddLike(string Mobile,int ProductID)
        {
            var UserID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            var DetileProduct = await facadProduct.IGetProductByIDServices.AnyGetProduct(ProductID);
            if (DetileProduct && UserID > 0)
            {
                bool isAddLike = await _IAddToLikeUser.AddToLike(UserID, ProductID);
                if (!isAddLike)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("ListLike", "Product", new { Mobile = Mobile });

            }
            return RedirectToAction("Index", "Home");

        }
        //[HttpGet]
        //public async Task<IActionResult> LikeProductUser(string Mobile)
        //{
        //    return View();
        //}
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CartUserShowActive(string Mobile)
        {
            CartUserDto CartUser = await _Cart.GetCartActive(Mobile ?? "");
            return View("~/Views/Product/CartUserShow.cshtml", CartUser);
        }
    }
}
