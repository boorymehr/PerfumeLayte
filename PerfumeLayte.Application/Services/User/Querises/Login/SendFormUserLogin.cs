using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Querises.Login
{
    public class SendFormUserLogin
    {
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [RegularExpression(@"^(\+98|0)?9\d{9}$", ErrorMessage = "فرمت وارد شده اشتباه است")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [MinLength(8, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool isMembered { get; set; }


        public enum ResualtLogin
        {
            None,
            Success,
            isActive
        }
    }
}
