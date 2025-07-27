using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Querises.GetCartActive
{
    public interface IGetCartUserActive
    {
        Task<CartUserDto> GetCartActive(string Mobile);
    }
}
