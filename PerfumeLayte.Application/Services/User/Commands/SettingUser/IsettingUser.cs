using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;

namespace PerfumeLayte.Application.Services.User.Commands.SettingUser
{
    public interface IsettingUser
    {
        Task<bool> Execute(UserSettingDto Setting);


        Task<bool> AddressSetting(int ID,string Adress);
    }
}
