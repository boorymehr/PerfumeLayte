using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeLayte.Application.Interfaces.Contexts;
using PerfumeLayte.Domain.Entity.User;

namespace PerfumeLayte.Application.Services.Product.Querises.UserPermition
{
    public class UserPermition : IUserPermition
    {
        private IDataBaseContext _context;
        public UserPermition(IDataBaseContext context)
        {
            _context = context;
        }

        public bool Execut(int UserID)
        {
            return _context.User.Where(u => u.ID == UserID && u.isActive).AsQueryable().Any(u => u.isAdmin);
        }

        public int Execut(string Mobile)
        {
            return _context.User.Where(u => u.Mobile == Mobile).Select(u => u.ID).SingleOrDefault();
        }
    }
}
