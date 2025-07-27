using Microsoft.AspNetCore.Mvc;
using PerfumeLayte.Application.Services.User.Commands.Register;

namespace Perfume_Layte.Controllers
{
    public class RegisterController : Controller
    {
        private IServisesRegister _ServisesRegister;
        public RegisterController(IServisesRegister ServisesRegister)
        {
            _ServisesRegister = ServisesRegister;
        }
        #region Register User
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(SendFormUserRegister Register)
        {
             if(ModelState.IsValid)
            {
                var ResRegister = await _ServisesRegister.Execute(Register);
                if(ResRegister)
                {
                    TempData["Mobile"] = Register.Mobile;
                    return RedirectToAction("SendSms", "Login", Register.Mobile);
                }
                else
                {
                    ModelState.AddModelError("Mobile", "کاربر وجود دارد باید وارد شوید");
                    return View();
                }
            }
           else
            {
                ModelState.AddModelError("Mobile","اطلاعات وارد شده اشتباه است");
                return View();
            }
        }
        #endregion
    }
}
