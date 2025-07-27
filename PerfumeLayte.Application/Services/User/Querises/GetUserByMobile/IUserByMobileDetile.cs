using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Services.User.Commands.SettingUser;

namespace PerfumeLayte.Application.Services.User.Querises.GetUserByMobile
{
    public interface IUserByMobileDetile
    {
        Task<UserSettingDto> GetByMobileDetile(string Mobile);


        Task<int> GetByUserMobileRetunID(string Mobile);


        Task<string> GetUserAdressByMobile(string Mobile);


    }
}
