using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Application.Services.User.Querises.GetCartActive
{
    public class CartUserDto
    {
        public string price { get; set; }
        public virtual List<CartItemDto> CartItemDto { get; set; }
    }
}
