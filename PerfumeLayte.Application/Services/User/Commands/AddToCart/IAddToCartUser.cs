using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Commands.AddToCart
{
    public interface IAddToCartUser
    {
        Task<bool> Execut(int UserID, int ProductID,int Count = 0);


        Task<bool> AddAdress(string Address, string Mobile);


        Task<bool> DeleteCartItem(string Mobile, int ProductID);



        Task<decimal> UpdateDatabasePrice(int id);




        Task<bool> PluseCart(int UserID, int ProdyctID);
        Task<bool> RemCart(int UserID, int ProdyctID);






    }
}

