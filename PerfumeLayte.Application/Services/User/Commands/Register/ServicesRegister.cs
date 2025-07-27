using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.User.Querises.Login;
using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.User.Commands.Register
{
    public class ServicesRegister : IServisesRegister
    {
        private readonly IDataBaseContext _context;
        private readonly IGetUserServiceLogin Login;
        public ServicesRegister(IGetUserServiceLogin _Login, IDataBaseContext context)
        {
            Login = _Login;
            _context = context;
        }
        public async Task<bool> Execute(SendFormUserRegister Register)
        {
            var IsUserByMobile = await Login.isUserByMobile(Register.Mobile);
            if(!IsUserByMobile)
            {
                PasswordHasher PassHash = new PasswordHasher();
                Random rnd = new Random();
                int CodePass = rnd.Next(100000, 999999);
                PerfumeLayte.Domain.Entity.User.User UserNe = new Domain.Entity.User.User()
                {
                    FullName = Register.FullName,
                    Password = PassHash.HashPassword(Register.Password),
                    CodeSmsPassword = CodePass.ToString(),
                    CodePost = "",
                    Email = "",
                    Mobile = Register.Mobile,
                    Address = "",
                };
                await _context.User.AddAsync(UserNe);
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
