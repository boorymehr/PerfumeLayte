using System.Collections.Generic;

namespace PerfumeLayte.Application.Services.User.Querises.GetUsers
{
    public class ReslutGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
