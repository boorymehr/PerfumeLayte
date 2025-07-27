using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.User.Querises.GetUserByMobile;
using PerfumeLayte.Application.Services.User.Querises.Login;
using PerfumeLayte.Comman;

namespace PerfumeLayte.Application.Services.User.Commands.SettingUser
{
    public class settingUser : IsettingUser
    {
        private readonly IDataBaseContext _context;
        public settingUser(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> AddressSetting(int ID, string Adress)
        {
            try
            {
                var User = await _context.User.FindAsync(ID);
                User.Address = Adress;
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Execute(UserSettingDto Setting)
        {
            PasswordHasher PassHash = new PasswordHasher();
            var UserGet = await _context.User.Where(u => u.Mobile == Setting.Mobile && u.isActive).AsQueryable().SingleOrDefaultAsync();

            if (UserGet != null)
            {
                bool isMatch = PassHash.VerifyPassword(UserGet.Password, Setting.PasswordNew);
                if(isMatch)
                {
                    UserGet.FullName = Setting.FullName;
                    UserGet.Password = PassHash.HashPassword(Setting.PasswordNew);
                    UserGet.CodePost = Setting.CodePost;

                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
