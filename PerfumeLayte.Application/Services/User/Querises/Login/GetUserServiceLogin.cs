using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Application.Services.User.Querises.Login;
using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.User;
using static PerfumeLayte.Application.Services.User.Querises.Login.SendFormUserLogin;

namespace PerfumeLayte.Application.Services.User.Querises.Login
{
    public class GetUserServiceLogin : IGetUserServiceLogin
    {
        private readonly IDataBaseContext _context;
        public GetUserServiceLogin(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<GetUserDto> GetUserByMobile(string Mobile)
        {
            return await _context.User.Where(u => u.Mobile == Mobile).Select(u => new GetUserDto()
            {
                Mobile = u.Mobile,
                Password = u.Password
            }).SingleOrDefaultAsync();
        }


        public async Task<ResualtLogin> Execute(SendFormUserLogin Login)
        {
            bool Res = await this.isUserByMobile(Login.Mobile);
            if(Res)
            {
                GetUserDto user =  await this.GetUserByMobile(Login.Mobile);
                PasswordHasher PassHash = new PasswordHasher();
                bool PasswordHash = PassHash.VerifyPassword(user.Password,Login.Password);
               if (user.Mobile == Login.Mobile && PasswordHash)
                {
                    var isActive = await this.isUserActive(Login.Mobile);
                    if (!isActive)
                    {
                        return ResualtLogin.isActive;
                    }
                    else
                    {
                        return ResualtLogin.Success;
                    }
                }

            }


            return ResualtLogin.None;
        }

        public async Task<bool> UserActive(string Mobile,string Code)
        {
            try
            {
                var User = await _context.User.AsQueryable().SingleOrDefaultAsync(u => u.Mobile == Mobile && u.CodeSmsPassword == Code);
                User.isActive = true;
                Random rnd = new Random();
                int CodePass = rnd.Next(100000, 999999);
                User.CodeSmsPassword = CodePass.ToString();
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> isUserActive(string Mobile)
        {
            return await _context.User.AnyAsync(p => p.isActive);
        }
        public async Task<bool> isUserByMobile(string Mobile)
        {
            return await _context.User.AnyAsync(p => p.Mobile == Mobile);
        }

        public async Task<string> GetCodeUserSms(string Mobile)
        {
            return await _context.User.Where(u => u.Mobile == Mobile).AsQueryable().Select(u => u.CodeSmsPassword).SingleOrDefaultAsync();
        }
    }
}
