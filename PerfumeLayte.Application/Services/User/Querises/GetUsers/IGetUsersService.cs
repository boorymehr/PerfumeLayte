using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Querises.GetUsers
{
    public interface IGetUsersService
    {
        Task<ReslutGetUserDto> Execute(RequestGetUserDto request);
    }
}
