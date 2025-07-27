

using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.User.Commands.SettingUser;

namespace PerfumeLayte.Application.Services.User.Querises.GetUserByMobile
{
    public class UserByMobileDetile : IUserByMobileDetile
    {
        private readonly IDataBaseContext _Context;
        public UserByMobileDetile(IDataBaseContext Context)
        {
            _Context = Context;
        }
        public async Task<UserSettingDto> GetByMobileDetile(string Mobile)
        {
            return await _Context.User.Where(u => u.Mobile == Mobile).AsQueryable().Select(u => new UserSettingDto()
            {
                FullName = u.FullName,
                Mobile = u.Mobile,
                CodePost = u.CodePost,
                Email = u.Email
            }).SingleOrDefaultAsync(); 
        }

        public async Task<int> GetByUserMobileRetunID(string Mobile)
        {
            return await _Context.User.Where(u => u.Mobile == Mobile).AsQueryable().Select(u => u.ID).SingleOrDefaultAsync();
        }

        public async Task<string> GetUserAdressByMobile(string Mobile)
        {
            return await _Context.User.Where(u => u.Mobile == Mobile).Select(u => u.Address).SingleOrDefaultAsync();
        }
    }
}