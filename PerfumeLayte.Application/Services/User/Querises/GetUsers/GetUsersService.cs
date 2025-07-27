
using System;
using System.Collections.Generic;
using System.Linq;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Comman;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.User.Querises.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }


        public async Task<ReslutGetUserDto> Execute(RequestGetUserDto request)
        {
            IQueryable<PerfumeLayte.Domain.Entity.User.User> users =  _context.User.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.Email.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int rowsCount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                ID = p.ID,
                Name = p.Email,
                Mobile = p.Mobile
            }).ToList();

            var res =  new ReslutGetUserDto
            {
                Rows = rowsCount,
                Users = usersList,
            };


            return res;
        }
    }
}
