using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Domain.Entity.User;
using PerfumeLayte.Application.Interfaces.IFacadPattern;
using PerfumeLayte.Application.Services.User.Querises.Login;
using static PerfumeLayte.Application.Services.User.Querises.Login.SendFormUserLogin;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Perfume_Layte.Controllers
{
    public class Login : Controller
    {
        private readonly IGetUserServiceLogin _Login;
        public Login(IGetUserServiceLogin Login)
        {
            _Login = Login;
        }
        #region LOGIN USER
        [HttpGet]
        public async Task<IActionResult> LoginUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(SendFormUserLogin Login)
        {
            if (ModelState.IsValid)
            {
                ResualtLogin res = await _Login.Execute(Login);
                if (res == ResualtLogin.Success)
                {
                    var claims = new List<Claim>
                          {
                         new Claim(ClaimTypes.Name, Login.Mobile)
                           };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = Login.isMembered,
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                    ViewData["Success"] = "با موفقیت انجام شد";
                    return View();
                }
                else if (res == ResualtLogin.isActive)
                {
                   
                    ViewData["isActive"] = "کاربر فعال نیست";
                    ViewData["MobileUser"] = Login.Mobile;
                    TempData["Mobile"] = Login.Mobile;
                    return View();
                }
                else if (res == ResualtLogin.None)
                {
                    ViewData["none"] = "کاربر موجود نیست";
                    return View();
                }
                return View(ModelState);
            }
            ModelState.AddModelError("Mobile", "شماره وارد شده اشتباه است");
            return View(ModelState);
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> SendSms(string Mobile)
        {
            string MobileUser = TempData["Mobile"].ToString();
            var CodeSms = await _Login.GetCodeUserSms(Mobile);
            TempData["MessageRegister"] = "ثبت نام انجام شد کدی برای فعال سازی به شماره همراه ارسال شد";
            //Send Mobilew
            return View(viewName: "SendSms",model: MobileUser);
        }
        [HttpPost]
        public async Task<IActionResult> SendSms(string Mobile, string CodeActive)
        {
            var ISMobile = await _Login.isUserByMobile(Mobile);
            if(!ISMobile)
            {

                return RedirectToAction("LoginUser");
            }
            else
            {
                var ActiveUser = await _Login.UserActive(Mobile, CodeActive);
                TempData["MessageSucess"] = "send";
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }






    }
}
