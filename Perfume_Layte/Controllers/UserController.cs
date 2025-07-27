using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Services.User.Commands.AddToCart;
using PerfumeLayte.Application.Services.User.Commands.SettingUser;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;
using PerfumeLayte.Application.Services.User.Querises.GetListCart;
using Microsoft.CodeAnalysis.CSharp;
using PerfumeLayte.Application.Services.Product.FacadProduct;
namespace Perfume_Layte.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAddToCartUser _IAddToCartUser;
        private readonly IsettingUser _IsettingUserServisec;
        private readonly IUserByMobileDetile _IUserByMobileDetile;
        private readonly ICartListAndLikeUser _ICartListAndLikeUser;
        public UserController(IUserByMobileDetile IUserByMobileDetileIsettingUser,
            IsettingUser _IsettingUser, IAddToCartUser IAddToCartUser
            , ICartListAndLikeUser ICartListAndLikeUser)
        {
            _IUserByMobileDetile = IUserByMobileDetileIsettingUser;
            _IsettingUserServisec = _IsettingUser;
            _IAddToCartUser = IAddToCartUser;
            _ICartListAndLikeUser = ICartListAndLikeUser;

        }
        [HttpGet]
        public async Task<IActionResult> Index(string Message)
        {

            var models = await _IUserByMobileDetile.GetByMobileDetile(User.Identity.Name.ToString());
            string Address = await _IUserByMobileDetile.GetUserAdressByMobile(User.Identity.Name);
            List<UserListCartDto> CartUserList = await _ICartListAndLikeUser.GetListCartUser(User.Identity.Name.ToString());
            if (Address != null)
            {
                ViewData["Adress"] = Address;
            }
            if(CartUserList != null)
            {
                ViewData["CartUserList"] = CartUserList;
            }


            ViewData["SuccessSetting"] = Message;
            return View(models);
        }







        #region Settings







        [HttpPost]
        public async Task<IActionResult> Setting(UserSettingDto UserSetting)
        {
            string Message = "تنظیمات انجام شد";
            if (ModelState.IsValid)
            {
                var result = await _IsettingUserServisec.Execute(UserSetting);
                if(result)
                {
                    return RedirectToAction("Index", "User", new { Message = Message });
                }
                else
                {
                    Message = "مقادیر اشتباه هستند";
                    return RedirectToAction("Index", "User", new { Message = Message });
                }

                
            }
            ModelState.AddModelError("FullName","مقادیر اشتباه هستند");
            Message = "مقادیر اشتباه هستند";
            return RedirectToAction("Index", "User", new { Message = Message });
        }

        [HttpPost]
        public async Task<IActionResult> Adress(string Adress,string Mobile)
        {
            string message;
            bool isAddAddress = await _IAddToCartUser.AddAdress(Adress, Mobile);
           if(isAddAddress)
            {
                message = "تنظیمات انجام شد";
                return RedirectToAction("Index", "User", new { Message = message });
            }
            message = "مقادیر اشتباه هستند";
            return RedirectToAction("Index", "User", new { Message = message });
        }

        #endregion


        [HttpGet]
        public async Task<IActionResult> RemoveCartItem(int ProductID,string Mobile)
        {
            bool Delete = await _IAddToCartUser.DeleteCartItem(Mobile, ProductID);
            return Redirect("/");
        }





        [HttpPost]
        public async Task<IActionResult> AddressSetting(string Mobile,string Address)
        {
            var UserID = await _IUserByMobileDetile.GetByUserMobileRetunID(Mobile);
            if(UserID > 0)
            {
                bool isAdressEdit = await _IsettingUserServisec.AddressSetting(UserID, Address);
                if(isAdressEdit)
                {
                    return RedirectToAction("Index","User", new { Message = "با موفقیت ادرس تغییر گردید"});
                }
                return RedirectToAction("Index", "User", new { Message = "عملیات با خطا مواجه شد" });
            }
            return RedirectToAction("Index", "User", new { Message = "عملیات با خطا مواجه شد" });
        }
    }
}
