using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Commands.SettingUser
{
    public class UserSettingDto
    {
        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }



        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "نام نام خانوادگی")]
        public string FullName { get; set; }





        [Display(Name = "کد پستی")]
        public string CodePost { get; set; }



        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [MinLength(8, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        public string PasswordBefore { get; set; }


        [Display(Name = "تکرار رمز عبور ")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [MinLength(8, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]

        public string PasswordNew { get; set; }
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "{0} نمیتواند خالی باشد")]
        [MinLength(8, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        [MaxLength(16, ErrorMessage = "{0} نمیتواند کمتر از 8 کاراکتر باشد")]
        [Compare("PasswordNew", ErrorMessage = "با رمز عبور همخانی ندارد")]
        public string RePasswordNew { get; set; }
    }
}
