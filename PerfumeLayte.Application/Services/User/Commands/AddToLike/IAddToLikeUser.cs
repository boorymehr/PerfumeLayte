using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.User.Commands.AddToLike
{
    public interface IAddToLikeUser
    {
        Task<List<LikeDto>> GetListLikeUser(int UserID);


        Task<bool> AddToLike(int UserID,int ProductID);


        Task<bool> RemToLike(int UserID, int ProductID);

    }
}
