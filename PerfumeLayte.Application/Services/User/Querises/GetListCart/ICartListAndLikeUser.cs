using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Application.Services.User.Querises.GetCartActive;

namespace PerfumeLayte.Application.Services.User.Querises.GetListCart
{
    public interface ICartListAndLikeUser
    {
        Task<List<LikeUserProductDto>> GetListLikeUser();


        Task<List<UserListCartDto>> GetListCartUser(string Mobile);
    }
}
