using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Services.User.Commands.Register;
using static PerfumeLayte.Application.Services.User.Commands.Register.SendFormUserRegister;

namespace PerfumeLayte.Application.Services.User.Commands.Register
{
    public interface IServisesRegister
    {
        Task<bool> Execute(SendFormUserRegister Register);
    }
}
