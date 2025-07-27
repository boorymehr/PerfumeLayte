using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.User;
using static PerfumeLayte.Application.Services.User.Querises.Login.SendFormUserLogin;

namespace PerfumeLayte.Application.Services.User.Querises.Login
{
    public interface IGetUserServiceLogin
    {
        Task<ResualtLogin> Execute(SendFormUserLogin Login);

        Task<bool> isUserByMobile(string Mobile);


        Task<string> GetCodeUserSms(string Mobile);

        Task<bool> UserActive(string Mobile,string Code);
        Task<bool> isUserActive(string Mobile);


        Task<GetUserDto> GetUserByMobile(string Mobile);
    }
}
