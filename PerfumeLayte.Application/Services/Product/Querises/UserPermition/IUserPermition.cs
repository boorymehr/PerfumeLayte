using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.Product.Querises.UserPermition
{
    public interface IUserPermition
    {
        bool Execut(int UserID);


        int Execut(string Mobile);
    }
}
